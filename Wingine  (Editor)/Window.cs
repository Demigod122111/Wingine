using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wingine.SceneManagement;
using Wingine.UI;
using XCoolForm;

namespace Wingine.Editor
{
    public partial class Window : XCoolForm.XCoolForm
    {
        public static Runner Runner = new Runner();

        public int TARGET_FPS = 60;

        object preSelectedObject;
        object SelectedObject;

        bool preventHierarchyNodeClick_Once = false;

        RichTextBox EditorLogs = new RichTextBox();

        #region Hierarchy

        Dictionary<string, TreeNode> HierarchyItems = new Dictionary<string, TreeNode>();
        Dictionary<TreeNode, bool> HierarchyItemsExpansion = new Dictionary<TreeNode, bool>();

        // Missing XML comment for publicly visible type or member 'Window.ReloadHierarchyObject(GameObject)'
        public void ReloadHierarchyObject(GameObject go)
        {
            LoadHierarchy(true);
        }

        // Missing XML comment for publicly visible type or member 'Window.LoadHierarchy(bool, List<GameObject>)'
        public void LoadHierarchy(bool fully = true, List<GameObject> partials = null)
        {
            if (fully)
            {
                Hierarchy.Nodes.Clear();
                HierarchyItems.Clear();
                HierarchyItemsExpansion.Clear();
            }

            void AddGameObject(GameObject go, TreeNode parent)
            {
                string id = DateTime.Now.Ticks.ToString();
                go.SetInspectorID(id);

                TreeNode node = null;

                if (HierarchyItems.ContainsKey(id))
                {
                    HierarchyItems[id].Remove();
                    parent?.Nodes.Add(HierarchyItems[id]);
                }
                else
                {
                    node = parent != null ? parent.Nodes.Add(go.Name) : Hierarchy.Nodes.Add(go.Name);
                    HierarchyItems.Add(id, node);
                    HierarchyItemsExpansion.Add(node, node.IsExpanded);
                }

                if (node != null)
                {
                    node.Tag = go;
                    go.SetActive(go.ActiveSelf);
                }
            }

            List<GameObject> Loaded = new List<GameObject>();
            void LoadGameObjects(List<GameObject> gos)
            {
                List<GameObject> Unloaded = new List<GameObject>();

                EditorLogs.Parent = this;
                EditorLogs.SendToBack();
                EditorLogs.Location = new Point(Width / 2, Height / 2);
                for (int i = 0; i < gos.Count; i++)
                {
                    var go = gos[i];

                    if (Loaded.Contains(go)) continue;

                    EditorLogs.AppendText($"Loading {go.Name}");


                    if (go.Parent != null)
                    {
                        LoadGameObjects(new List<GameObject> { go.Parent });

                        string piid = go.Parent.GetInspectorID();

                        AddGameObject(go, HierarchyItems[piid]);
                    }
                    else
                    {
                        AddGameObject(go, null);
                    }

                    Loaded.Add(go);
                }

            }

            if (Runner.App.CurrentScene != null)
            {
                LoadGameObjects(fully == true ? Runner.App.CurrentScene.GameObjects : partials);
            }
        }
        #endregion

        #region Inspector
        ButtonInputField AddComponent = new ButtonInputField();

        EventHandler ACEH;
        public void ClearInspector()
        {
            SelectedObject = null;
            Inspector.Controls.Clear();
            AddComponent.Action.Click -= ACEH;
        }

        bool cancelLoadGameObjectInspector = false;

        Panel CoverPanel;
        Label CoverPanelText;

        public async void LoadGameObjectInspector(GameObject go)
        {
            if (go == null)
            {
                ClearInspector();
                return;
            }

            CoverPanelText.Text = $"Probing '{go.Name}'";
            CoverPanel.BringToFront();

            var task = new Task(() =>
            {
                HandleLoadGameObjectInspector(go);
            }, new CancellationToken(cancelLoadGameObjectInspector));
            task.RunSynchronously();

            await Task.Run(() =>
            {
                while (!task.IsCompleted) { }
            });

            CoverPanel.SendToBack();
        }

        public void HandleLoadGameObjectInspector(GameObject go)
        {
            
            int InspectorItemHeight = 49;
            int InspectorItemPadding = 10;

            Inspector.Controls.Clear();

            CoverPanel.BringToFront();
            Inspector.SuspendLayout();

            var nameInputField = new BaseInputField();
            nameInputField.Title.Text = "Name";
            nameInputField.Value.Text = go.Name;
            nameInputField.Parent = Inspector;
            nameInputField.Location = new Point(0, 0);
            nameInputField.Size = new Size(Inspector.Width, InspectorItemHeight);
            nameInputField.Parent = Inspector;
            nameInputField.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            nameInputField.Tag = go.GetType().GetField("Name");
            nameInputField.ValueObject = go;
            nameInputField.Value.TextChanged += (s, e) =>
            {
                try
                {
                    go.Name = nameInputField.Value.Text;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                }
            };

            var activeInputField = new BoolInputField();
            activeInputField.Title.Text = "Active";
            activeInputField.Value.Checked = go.ActiveSelf;
            activeInputField.Parent = Inspector;
            activeInputField.Location = new Point(0, InspectorItemHeight + InspectorItemPadding);
            activeInputField.Size = new Size(Inspector.Width, InspectorItemHeight);
            activeInputField.Parent = Inspector;
            activeInputField.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            activeInputField.Tag = go.GetType().GetProperty("ActiveSelf");
            activeInputField.ValueObject = go;
            activeInputField.Value.CheckedChanged += (s, e) =>
            {
                try
                {
                    go.SetActive(activeInputField.Value.Checked);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                }
            };

            var tagInputField = new BaseInputField();
            tagInputField.Title.Text = "Tag";
            tagInputField.Value.Text = go.Tag;
            tagInputField.Parent = Inspector;
            tagInputField.Location = new Point(0, 2 * (InspectorItemHeight + InspectorItemPadding));
            tagInputField.Size = new Size(Inspector.Width, InspectorItemHeight);
            tagInputField.Parent = Inspector;
            tagInputField.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            tagInputField.Tag = go.GetType().GetField("Tag");
            tagInputField.ValueObject = go;
            tagInputField.Value.TextChanged += (s, e) =>
            {
                try
                {
                    go.Tag = tagInputField.Value.Text;
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                }
            };


            Point NewPos = new Point(0, tagInputField.Location.Y + InspectorItemHeight + InspectorItemPadding);

            List<IComponent> comps = go.GetComponents();

            for (int i = 0; i < comps.Count; i++)
            {
                LoadComponent(comps[i], i == comps.Count - 1);
            }


            void LoadComponent(IComponent comp, bool last)
            {
                var head = new ComponentHeader();
                head.Title.Text = comp.GetType().Name;

                if (comp == go.Transform)
                {
                    head.X.Parent = null;
                    head.CB.Parent = null;
                }

                head.CB.Checked = true;
                head.CB.CheckedChanged += (s, e) =>
                {
                    comp.Enabled = head.CB.Checked;
                };

                head.X.Click += (s, e) =>
                {
                    go.RemoveComponent(comp);
                    LoadGameObjectInspector(go);
                };
                AddItemToInspector(head);


                var members = comp.GetType().GetMembers();

                for (int i = 0; i < members.Length; i++)
                {
                    if (members[i].MemberType == MemberTypes.Field)
                    {
                        LoadField((FieldInfo) members[i]);
                    }
                    else if (members[i].MemberType == MemberTypes.Property)
                    {
                        LoadProperty((PropertyInfo)members[i]);
                    }
                }

                void LoadProperty(PropertyInfo prop)
                {
                    var member = prop;

                    if (member.GetSetMethod() == null || !member.GetSetMethod().IsPublic) return;

                    Type t = member.PropertyType;

                    if (Attribute.IsDefined(member, typeof(Wingine.HideInInspector)))
                    {
                        return;
                    }

                    if (Attribute.IsDefined(member, typeof(Wingine.Header)))
                    {
                        Wingine.Header hdr = ((Wingine.Header[])member.GetCustomAttributes(typeof(Wingine.Header), false))[0];
                        var hdrd = new ComponentSubHeader();
                        hdrd.Title.Text = hdr.Text;
                        AddItemToInspector(hdrd);
                    }

                    if (Attribute.IsDefined(member, typeof(Wingine.Space)))
                    {
                        Wingine.Space spce = ((Wingine.Space[])member.GetCustomAttributes(typeof(Wingine.Space), false))[0];
                        NewPos = new Point(NewPos.X, NewPos.Y + spce.Spacing);
                    }

                    #region Types

                    if (t.IsEnum)
                    {
                        var inputField = new EnumInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();

                        var possibleValues = Enum.GetValues(t);

                        foreach (var val in possibleValues)
                        {
                            inputField.Value.Items.Add(val);
                        }
                        inputField.Value.SelectedItem = member.GetValue(comp);
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        EventHandler col = (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, Enum.Parse(t, inputField.Value.Items[inputField.Value.SelectedIndex].ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        inputField.Value.SelectedIndexChanged += col;

                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(Action))
                    {
                        if (Attribute.IsDefined(member, typeof(Wingine.ActionButton)))
                        {
                            var inputField = new ButtonInputField();
                            inputField.Name = member.Name;
                            inputField.Title.Parent = null;
                            inputField.Height = inputField.Action.Height;
                            inputField.Action.Dock = DockStyle.Fill;
                            inputField.Action.Text = member.Name.AddSpacesToSentence();
                            inputField.Tag = member;
                            inputField.ValueObject = comp;
                            EventHandler col = (s, e) =>
                            {
                                try
                                {
                                    Wingine.ActionButton ab = ((Wingine.ActionButton[])member.GetCustomAttributes(typeof(Wingine.ActionButton), false))[0];
                                    ((Action)member.GetValue(comp)).DynamicInvoke(ab.Arguments);
                                    if (ab.ReloadInspector)
                                    {
                                        var so = SelectedObject;
                                        ClearInspector();
                                        LoadGameObjectInspector((GameObject)so);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                                }

                                comp.Tick();
                            };
                            inputField.Action.Click += col;

                            AddItemToInspector(inputField);
                        }
                    }
                    else if (t == typeof(Color))
                    {
                        if (Attribute.IsDefined(member, typeof(Wingine.ExtendColor)))
                        {
                            var inputField = new ExtendedColorInputField();
                            inputField.Name = member.Name;
                            inputField.Title.Text = member.Name.AddSpacesToSentence();
                            inputField.Value.Color = (Color)member.GetValue(comp);
                            inputField.Tag = member;
                            inputField.ValueObject = comp;
                            EventHandler col = (s, e) =>
                            {
                                try
                                {
                                    member.SetValue(comp, inputField.Value.Color);
                                }
                                catch (Exception ex)
                                {
                                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                                }

                                comp.Tick();
                            };
                            inputField.Value.ColorChanged += col;
                            inputField.Value2.ColorChanged += col;

                            AddItemToInspector(inputField);
                        }
                        else
                        {
                            var inputField = new ColorInputField();
                            inputField.Name = member.Name;
                            inputField.Title.Text = member.Name.AddSpacesToSentence();
                            inputField.Value.Color = (Color)member.GetValue(comp);
                            inputField.Tag = member;
                            inputField.ValueObject = comp;
                            EventHandler col = (s, e) =>
                            {
                                try
                                {
                                    member.SetValue(comp, inputField.Value.Color);
                                }
                                catch (Exception ex)
                                {
                                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                                }

                                comp.Tick();
                            };
                            inputField.Value.ColorChanged += col;
                            inputField.Value2.ColorChanged += col;

                            AddItemToInspector(inputField);
                        }
                    }
                    else if (t == typeof(Action))
                    {
                        var inputField = new ButtonInputField();
                        inputField.Name = member.Name;
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Action.Text = member.Name.AddSpacesToSentence();
                        inputField.Title.Text = "";
                        inputField.Action.Tag = t;
                        inputField.Action.Click += (s, e) =>
                        {
                            try
                            {

                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }
                        };
                        //AddItemToInspector(inputField);
                    }
                    else if (t == typeof(bool))
                    {
                        var inputField = new BoolInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Value.Checked = (bool)member.GetValue(comp);
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.CheckedChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, inputField.Value.Checked);
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(Vector2))
                    {
                        var inputField = new VectorInputField();
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Name = member.Name;
                        inputField.Tag = member;
                        inputField.ValueObject = comp;

                        inputField.Value1.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value1.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value1.DecimalPlaces = 15;
                        inputField.Value2.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value2.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value2.DecimalPlaces = 15;

                        inputField.Value1.Value = decimal.Parse(((Vector2)member.GetValue(comp)).X.ToString());
                        inputField.Value2.Value = decimal.Parse(((Vector2)member.GetValue(comp)).Y.ToString());
                        inputField.Value1.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, new Vector2(double.Parse(inputField.Value1.Value.ToString()), double.Parse(inputField.Value2.Value.ToString())));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        inputField.Value2.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, new Vector2(double.Parse(inputField.Value1.Value.ToString()), double.Parse(inputField.Value2.Value.ToString())));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(long))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, long.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(int))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, int.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(float))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.DecimalPlaces = 7;
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, float.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(double))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.DecimalPlaces = 15;
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, double.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(string))
                    {
                        var inputField = new BaseInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Text = $"{member.GetValue(comp)}";
                        inputField.Value.TextChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, inputField.Value.Text);
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };

                        if (Attribute.IsDefined(member, typeof(Wingine.Multiline)))
                        {
                            Wingine.Multiline mle = ((Wingine.Multiline[])member.GetCustomAttributes(typeof(Wingine.Multiline), false))[0];

                            inputField.Value.Multiline = true;
                            inputField.Height = inputField.Title.Height + mle.DefaultSize;
                            inputField.Value.Height = mle.DefaultSize;
                        }
                        AddItemToInspector(inputField);
                    }
                    else
                    {
                        var inputField = new BaseInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Text = $"{member.GetValue(comp)}";
                        inputField.Value.ReadOnly = true;
                        AddItemToInspector(inputField);
                    }
                    #endregion
                }

                void LoadField(FieldInfo field)
                {
                    var member = field;

                    if (!member.IsPublic || member.IsStatic || member.IsInitOnly) return;

                    Type t = member.FieldType;

                    if (Attribute.IsDefined(member, typeof(Wingine.HideInInspector)))
                    {
                        return;
                    }

                    if (Attribute.IsDefined(member, typeof(Wingine.Header)))
                    {
                        Wingine.Header hdr = ((Wingine.Header[])member.GetCustomAttributes(typeof(Wingine.Header), false))[0];
                        var hdrd = new ComponentSubHeader();
                        hdrd.Title.Text = hdr.Text;
                        AddItemToInspector(hdrd);
                    }

                    if (Attribute.IsDefined(member, typeof(Wingine.Space)))
                    {
                        Wingine.Space spce = ((Wingine.Space[])member.GetCustomAttributes(typeof(Wingine.Space), false))[0];
                        NewPos = new Point(NewPos.X, NewPos.Y + spce.Spacing);
                    }

                    #region Types
                    if (t.IsEnum)
                    {
                        var inputField = new EnumInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();

                        var possibleValues = Enum.GetValues(t);

                        foreach (var val in possibleValues)
                        {
                            inputField.Value.Items.Add(val);
                        }
                        inputField.Value.SelectedItem = member.GetValue(comp);
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        EventHandler col = (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, Enum.Parse(t, inputField.Value.Items[inputField.Value.SelectedIndex].ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        inputField.Value.SelectedIndexChanged += col;

                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(Action))
                    {
                        if (Attribute.IsDefined(member, typeof(Wingine.ActionButton)))
                        {
                            var inputField = new ButtonInputField();
                            inputField.Name = member.Name;
                            inputField.Title.Parent = null;
                            inputField.Height = inputField.Action.Height;
                            inputField.Action.Dock = DockStyle.Fill;
                            inputField.Action.Text = member.Name.AddSpacesToSentence();
                            inputField.Tag = member;
                            inputField.ValueObject = comp;
                            EventHandler col = (s, e) =>
                            {
                                try
                                {
                                    Wingine.ActionButton ab = ((Wingine.ActionButton[])member.GetCustomAttributes(typeof(Wingine.ActionButton), false))[0];
                                    ((Action)member.GetValue(comp)).DynamicInvoke(ab.Arguments);
                                    if (ab.ReloadInspector)
                                    {
                                        var so = SelectedObject;
                                        ClearInspector();
                                        LoadGameObjectInspector((GameObject)so);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                                }

                                comp.Tick();
                            };
                            inputField.Action.Click += col;

                            AddItemToInspector(inputField);
                        }
                    }
                    else if (t == typeof(Color))
                    {
                        if (Attribute.IsDefined(member, typeof(Wingine.ExtendColor)))
                        {
                            var inputField = new ExtendedColorInputField();
                            inputField.Name = member.Name;
                            inputField.Title.Text = member.Name.AddSpacesToSentence();
                            inputField.Value.Color = (Color)member.GetValue(comp);
                            inputField.Tag = member;
                            inputField.ValueObject = comp;
                            EventHandler col = (s, e) =>
                            {
                                try
                                {
                                    member.SetValue(comp, inputField.Value.Color);
                                }
                                catch (Exception ex)
                                {
                                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                                }

                                comp.Tick();
                            };
                            inputField.Value.ColorChanged += col;
                            inputField.Value2.ColorChanged += col;

                            AddItemToInspector(inputField);
                        }
                        else
                        {
                            var inputField = new ColorInputField();
                            inputField.Name = member.Name;
                            inputField.Title.Text = member.Name.AddSpacesToSentence();
                            inputField.Value.Color = (Color)member.GetValue(comp);
                            inputField.Tag = member;
                            inputField.ValueObject = comp;
                            EventHandler col = (s, e) =>
                            {
                                try
                                {
                                    member.SetValue(comp, inputField.Value.Color);
                                }
                                catch (Exception ex)
                                {
                                    Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                                }

                                comp.Tick();
                            };
                            inputField.Value.ColorChanged += col;
                            inputField.Value2.ColorChanged += col;

                            AddItemToInspector(inputField);
                        }
                    }
                    else if (t == typeof(bool))
                    {
                        var inputField = new BoolInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Value.Checked = (bool)member.GetValue(comp);
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.CheckedChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, inputField.Value.Checked);
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(Vector2))
                    {
                        var inputField = new VectorInputField();
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Name = member.Name;
                        inputField.Tag = member;
                        inputField.ValueObject = comp;

                        inputField.Value1.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value1.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value1.DecimalPlaces = 15;
                        inputField.Value2.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value2.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value2.DecimalPlaces = 15;

                        inputField.Value1.Value = decimal.Parse(((Vector2)member.GetValue(comp)).X.ToString());
                        inputField.Value2.Value = decimal.Parse(((Vector2)member.GetValue(comp)).Y.ToString());
                        inputField.Value1.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, new Vector2(double.Parse(inputField.Value1.Value.ToString()), double.Parse(inputField.Value2.Value.ToString())));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        inputField.Value2.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, new Vector2(double.Parse(inputField.Value1.Value.ToString()), double.Parse(inputField.Value2.Value.ToString())));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(long))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, long.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(int))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, int.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(float))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.DecimalPlaces = 7;
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, float.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(double))
                    {
                        var inputField = new NumberInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Minimum = decimal.Parse(int.MinValue.ToString());
                        inputField.Value.Maximum = decimal.Parse(int.MaxValue.ToString());
                        inputField.Value.Value = decimal.Parse(member.GetValue(comp).ToString());
                        inputField.Value.DecimalPlaces = 15;
                        inputField.Value.ValueChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, double.Parse(inputField.Value.Value.ToString()));
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };
                        AddItemToInspector(inputField);
                    }
                    else if (t == typeof(string))
                    {
                        var inputField = new BaseInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Text = $"{member.GetValue(comp)}";
                        inputField.Value.TextChanged += (s, e) =>
                        {
                            try
                            {
                                member.SetValue(comp, inputField.Value.Text);
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }

                            comp.Tick();
                        };

                        if (Attribute.IsDefined(member, typeof(Wingine.Multiline)))
                        {
                            Wingine.Multiline mle = ((Wingine.Multiline[])member.GetCustomAttributes(typeof(Wingine.Multiline), false))[0];

                            inputField.Value.Multiline = true;
                            inputField.Height = inputField.Title.Height + mle.DefaultSize;
                            inputField.Value.Height = mle.DefaultSize;
                        }
                        AddItemToInspector(inputField);
                    }
                    else
                    {
                        var inputField = new BaseInputField();
                        inputField.Name = member.Name;
                        inputField.Title.Text = member.Name.AddSpacesToSentence();
                        inputField.Tag = member;
                        inputField.ValueObject = comp;
                        inputField.Value.Text = $"{member.GetValue(comp)}";
                        inputField.Value.ReadOnly = true;
                        AddItemToInspector(inputField);
                    }
                    #endregion

                }

                if (last)
                {

                }
            }

            void AddItemToInspector(Control c)
            {
                c.Parent = Inspector;
                c.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
                c.Location = NewPos;
                c.Width = Inspector.Width;
                InspectorItemHeight = c.Height;
                NewPos = new Point(0, c.Location.Y + InspectorItemHeight + InspectorItemPadding);
            }


            AddComponent.Title.Text = "";
            AddComponent.Action.Text = "Add Component";
            AddComponent.Action.ForeColor = Color.Beige;
            ACEH = (s, e) =>
            {
                try
                {
                    ACM?.Dispose();
                }
                catch { }

                ACM = new ComponentMenu();

                ACM.View.NodeMouseClick += (s1, e1) =>
                {
                    ((GameObject)SelectedObject).AddComponent(e1.Node.Tag as Type);
                    ACM.Dispose();
                    LoadGameObjectInspector((GameObject)SelectedObject);
                };

                ACM.ShowDialog(this);
            };
            AddComponent.Action.Click += ACEH;
            AddItemToInspector(AddComponent.Action);

            Inspector.Visible = true;

            Inspector.ResumeLayout();
            CoverPanel.SendToBack();
        }

        ComponentMenu ACM;

        #endregion

        #region Assets Manager
        string homeAssetDirectory = "";
        string currentAssetDirectory = "";

        void AddAssetItem(string path)
        {
            var item = AssetListView.Items.Add(Path.GetFileName(path));
            if (File.Exists(path) && File.GetAttributes(path) != FileAttributes.Hidden)
            {
                AssetsImageList.Images.Add(path, Icon.ExtractAssociatedIcon(Path.GetFullPath(path)));
            }


            if (Directory.Exists(path))
            {
                item.ImageIndex = 0;
            }
            else
            {
                item.ImageKey = path;
            }

            item.Group = Directory.Exists(path) ? AssetListView.Groups[0] : AssetListView.Groups[1];

            item.Tag = path;
        }

        void ClearAssets()
        {
            AssetListView.Items.Clear();
        }

        void LoadAssetFolder(string folder)
        {
            currentAssetDirectory = folder;

            AssetLocation.Text = "   " + folder.Replace(@"\\", @"\").Replace(@"\", " > ");

            var flds = AssetLocation.Text.Split('>');
            var lst = flds[flds.Length - 1].TrimStart();
            var count = lst.Length;

            AssetLocation.Text = AssetLocation.Text.Remove(AssetLocation.Text.Length - count);
            AssetLocation.AppendText(lst, Color.DarkCyan);
            AssetLocation.SelectionStart = AssetLocation.Text.Length;
            AssetLocation.ScrollToCaret();

            ClearAssets();

            foreach (var subFolder in Directory.GetDirectories(folder))
            {
                if (IsDirectoryHidden(subFolder)) continue;
                AddAssetItem(subFolder);
            }

            foreach (var subFile in Directory.GetFiles(folder))
            {
                if (IsFileHidden(subFile)) continue;
                AddAssetItem(subFile);
            }
        }

        static bool IsFileHidden(string filePath)
        {
            FileAttributes attributes = File.GetAttributes(filePath);
            return (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
        }

        static bool IsDirectoryHidden(string directoryPath)
        {
            FileAttributes attributes = File.GetAttributes(directoryPath);
            return (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
        }
        #endregion

        #region Init
        Label EDITOR_FPS_STATUS = new Label();
        Label INSPECTOR_FPS_STATUS = new Label();
        Label HIERARCHY_FPS_STATUS = new Label();


        public Window(string proj, string homeAssetDir = "")
        {
            InitializeComponent();

            this.TitleBar.TitleBarCaptionFont = new Font("Algerian", 12);
            this.TitleBar.TitleBarCaptionColor = Color.MintCream;

            this.TitleBar.TitleBarType = XTitleBar.XTitleBarType.Angular;

            EDITOR_FPS_STATUS.TextAlign = ContentAlignment.MiddleLeft;
            EDITOR_FPS_STATUS.Font = new Font("Algerian", 12);
            EDITOR_FPS_STATUS.Parent = StatusBar;
            Editor.Interval = 1000 / TARGET_FPS;

            INSPECTOR_FPS_STATUS.TextAlign = ContentAlignment.MiddleLeft;
            INSPECTOR_FPS_STATUS.Font = new Font("Algerian", 12);
            INSPECTOR_FPS_STATUS.Parent = StatusBar;
            InspectorUpdater.Interval = 1000 / TARGET_FPS;

            HIERARCHY_FPS_STATUS.TextAlign = ContentAlignment.MiddleLeft;
            HIERARCHY_FPS_STATUS.Font = new Font("Algerian", 12);
            HIERARCHY_FPS_STATUS.Parent = StatusBar;
            HierarchyUpdater.Interval = 1000 / TARGET_FPS;

            Runner.App.RenderPlanes.Add(Scene);

            EventManagement();

            Open(proj, urgent: false);

            this.TitleBar.TitleBarCaption = $"{(string.IsNullOrEmpty(Runner.CurrentProject?.Item1) ? string.Empty : Runner.CurrentProject?.Item1 + " : ")}Wingine";

            Development();

            CoverPanel = new Panel();
            CoverPanel.Size = Inspector.Size;
            CoverPanel.Parent = Inspector.Parent;
            CoverPanel.BackColor = Inspector.BackColor;
            CoverPanel.Dock = Inspector.Dock;

            CoverPanelText = new Label();
            CoverPanelText.Parent = CoverPanel;
            CoverPanelText.AutoSize = false;
            CoverPanelText.Dock = DockStyle.Fill;
            CoverPanelText.TextAlign = ContentAlignment.MiddleCenter;
            CoverPanelText.BackColor = CoverPanel.BackColor;
            CoverPanelText.ForeColor = Color.Gold;
            CoverPanelText.Font = new Font("Microsoft Sans Serif", 11f, FontStyle.Bold);

            homeAssetDirectory = Directory.Exists(homeAssetDir) ? homeAssetDir : Environment.CurrentDirectory;

            debugRepeatToolStripMenuItem.Checked = Debug.CanRepeat;
        }
        #endregion

        #region Event Manager
        void EventManagement()
        {
            Wingine.Scene.OnGameObjectAdded += (go) =>
            {
                LoadHierarchy(fully: false, partials: new List<GameObject>() { go });
            };

            Wingine.Scene.OnGameObjectRemoved += (go) =>
            {
                HierarchyItems[go.GetInspectorID()].Remove();
                HierarchyItemsExpansion.Remove(HierarchyItems[go.GetInspectorID()]);
                HierarchyItems.Remove(go.GetInspectorID());
            };

            Wingine.Scene.OnGameObjectForceRemovedByAncestor += (ansc, go) =>
            {
                HierarchyItemsExpansion.Remove(HierarchyItems[go.GetInspectorID()]);
                HierarchyItems.Remove(go.GetInspectorID());
            };

            Wingine.GameObject.ParentChanged += (s, e) =>
            {
                GameObject go = (GameObject)s;

                ReloadHierarchyObject(go);
            };

            Wingine.GameObject.ActiveChanged += (s, e) =>
            {
                GameObject go = (GameObject)s;
                HierarchyItems[go.GetInspectorID()].ForeColor = go.ActiveInHierarchy() ? Color.Goldenrod : Color.DarkRed;
            };

            Wingine.GameObject.NameChanged += (s, e) =>
            {
                GameObject go = (GameObject)s;
                HierarchyItems[go.GetInspectorID()].Text = go.Name;
            };

            Wingine.Debug.CanRepeatChanged += (s, e) =>
            {
                debugRepeatToolStripMenuItem.Checked = Wingine.Debug.CanRepeat;
            };

            Wingine.Debug.DebugEventOccured += (msg, type) =>
            {
                var tmsg = $"[{type} | {DateTime.Now.TimeOfDay}]: {msg}\n";

                if (Wingine.Debug.Repeated(msg, type) && !Wingine.Debug.CanRepeat) return;

                switch (type)
                {
                    case Debug.DebugType.Log:
                        Console.AppendText(tmsg, Color.Beige);
                        break;
                    case Debug.DebugType.Warning:
                        Console.AppendText(tmsg, Color.LightGoldenrodYellow);
                        break;
                    case Debug.DebugType.Error:
                        Console.AppendText(tmsg, Color.Crimson);
                        break;
                    case Debug.DebugType.Editor:
                        Console.AppendText(tmsg, Color.MediumPurple);
                        break;
                    default:
                        Console.AppendText(tmsg, Color.Beige);
                        break;
                }
                Console.ScrollToCaret();
            };

            Wingine.SceneManagement.SceneManager.SceneLoaded += (s) =>
            {
                LoadHierarchy();
                ClearInspector();
                reloadToolStripMenuItem.PerformClick();
            };

            Wingine.Application.OnGameUpdate += (s, e) =>
            {

            };
        }
        #endregion

        #region Development
        void Development()
        {

        }

        #endregion

        #region Editor Events
        long elastSecond = DateTime.Now.Ticks;
        int efps = 0;

        long ilastSecond = DateTime.Now.Ticks;
        int ifps = 0;

        long hlastSecond = DateTime.Now.Ticks;
        int hfps = 0;


        private void Editor_Tick(object sender, EventArgs e)
        {
            UpdateEditor();
        }

        void UpdateEditor()
        {
            var currentSecond = DateTime.Now.Ticks;
            var tbln = currentSecond - elastSecond;

            if (tbln >= TimeSpan.TicksPerSecond)
            {
                elastSecond = currentSecond;
                EDITOR_FPS_STATUS.Text = $"E-FPS: {efps}";
                efps = 0;
            }
            else
            {
                efps++;
            }

            EDITOR_FPS_STATUS.Visible = showFPSToolStripMenuItem.Checked;
            HIERARCHY_FPS_STATUS.Visible = showFPSToolStripMenuItem.Checked;
            INSPECTOR_FPS_STATUS.Visible = showFPSToolStripMenuItem.Checked;

            if (Runner.App.CurrentScene != null && !Runner.App.IsRunning)
            {
                Runner.App.Render();

            }

            if (Runner.App.CurrentScene == null)
            {
                if (Runner.CurrentProject?.Item3?.Count != 0)
                {
                    SceneManager.LoadFirstScene();
                }
            }

            if (Runner.App.CurrentScene == null ||
                Runner.CurrentProject == null ||
                Runner.CurrentProject.Item3 == null ||
                Runner.CurrentProject.Item3.Count == 0)
            {
                HierarchyUpdater.Enabled = false;
                InspectorUpdater.Enabled = false;
            }
            else
            {
                HierarchyUpdater.Enabled = true;
                InspectorUpdater.Enabled = true;
            }


            debugRepeatToolStripMenuItem.Text = $"Debug Repeat ({(debugRepeatToolStripMenuItem.Checked ? "On" : "Off")})";
            clearOnPlayToolStripMenuItem.Text = $"Clear On Play ({(clearOnPlayToolStripMenuItem.Checked ? "On" : "Off")})";
        }

        private void Window_Load(object sender, EventArgs e)
        {
            LoadAssetFolder(homeAssetDirectory);
        }

        void ClearConsole()
        {
            Console.Text = "";
            Debug.lastMsg = null;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearConsole();
        }

        TreeNode dragNode = null;
        bool draggingNode => dragNode != null;
        private void Hierarchy_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dragNode = (TreeNode)e.Item;

        }

        private void Hierarchy_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            var hNode = e.Node;

            if(hNode != dragNode && draggingNode)
            {

            }
        }

        private void Hierarchy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                if (Hierarchy.SelectedNode != null)
                {
                    var node = Hierarchy.SelectedNode;
                    var parent = node.Parent;

                    node.Remove();

                    if (parent != null) parent.Nodes.Add(node);
                    else Hierarchy.Nodes.Add(node);
                    Hierarchy.SelectedNode = node;
                    node.EnsureVisible();

                    GameObject go = (GameObject)node.Tag;
                    Runner.App.CurrentScene.GameObjects.Remove(go);
                    Runner.App.CurrentScene.GameObjects.Insert(GetObjectIndex(go), go);
                }
            }
        }

        private void Hierarchy_MouseUp(object sender, MouseEventArgs e)
        {
            var ht = Hierarchy.HitTest(e.Location);

            Hierarchy.HideSelection = false;

            if (ht.Node == null)
            {
                Hierarchy.SelectedNode = null;
                Hierarchy.HideSelection = true;
                ClearInspector();
            }

            if (draggingNode)
            {
                Hierarchy.Nodes.Remove(dragNode);
                GameObject go = (GameObject)dragNode.Tag;

                if (ht.Node != null)
                {
                    if (e.Button != MouseButtons.Left)
                    {
                        if (ht.Node.Parent != null) {
                            var count = ht.Node.Index;
                            ht.Node.Parent.Nodes.Insert(count, dragNode);
                            ht.Node.Parent.Nodes[count].EnsureVisible();
                            go.SetParent((GameObject)ht.Node.Parent.Tag);
                        }
                        else
                        {
                            var count = ht.Node.Index;
                            Hierarchy.Nodes.Insert(count, dragNode);
                            Hierarchy.Nodes[count].EnsureVisible();
                            go.SetParent(null);
                        }
                    }
                    else
                    {
                        ht.Node.Nodes.Insert(0, dragNode);
                        ht.Node.Nodes[0].EnsureVisible();
                        go.SetParent((GameObject)ht.Node.Tag);
                    }
                }
                else
                {
                    var count = Hierarchy.Nodes.Count;
                    Hierarchy.Nodes.Insert(count, dragNode);
                    Hierarchy.Nodes[count].EnsureVisible();
                    go.SetParent(null);
                }

                HierarchyItems[go.GetInspectorID()] = dragNode;

                dragNode = null;

                Runner.App.CurrentScene.GameObjects.Remove(go);
                Runner.App.CurrentScene.GameObjects.Insert(GetObjectIndex(go), go);
            }
        }

        private void Hierarchy_MouseDown(object sender, MouseEventArgs e)
        {
            if (draggingNode)
            {
                dragNode = null;
            }
        }

        private void HierarchyUpdater_Tick(object sender, EventArgs e)
        {
            UpdateHierarchy();
        }

        void UpdateHierarchy()
        {
            var currentSecond = DateTime.Now.Ticks;
            var tbln = currentSecond - hlastSecond;

            if (tbln >= TimeSpan.TicksPerSecond)
            {
                hlastSecond = currentSecond;
                HIERARCHY_FPS_STATUS.Text = $"H-FPS: {hfps}";
                hfps = 0;
            }
            else
            {
                hfps++;
            }
        }

        List<GameObject> HAC = new List<GameObject>();
        private void Hierarchy_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ((GameObject)e.Node.Tag).SetActive(e.Node.Checked);
            HAC.Add((GameObject)e.Node.Tag);
        }

        private void Hierarchy_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void Hierarchy_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (HierarchyItemsExpansion.ContainsKey(e.Node) && e.Node.IsExpanded != HierarchyItemsExpansion[e.Node])
            {
                HierarchyItemsExpansion[e.Node] = e.Node.IsExpanded;
                return;
            }

            if (preventHierarchyNodeClick_Once)
            {
                preventHierarchyNodeClick_Once = false;
                return;
            }

            if (SelectedObject == e.Node.Tag) return;
            preSelectedObject = SelectedObject;
            SelectedObject = e.Node.Tag;
            LoadGameObjectInspector(e.Node.Tag as GameObject);
        }

        private void InspectorUpdater_Tick(object sender, EventArgs e)
        {
            UpdateInspector();
        }

        void UpdateInspector()
        {
            var currentSecond = DateTime.Now.Ticks;
            var tbln = currentSecond - ilastSecond;

            if (tbln >= TimeSpan.TicksPerSecond)
            {
                ilastSecond = currentSecond;
                INSPECTOR_FPS_STATUS.Text = $"I-FPS: {ifps}";
                ifps = 0;
            }
            else
            {
                ifps++;
            }

            var k = new List<Control>();
            try
            {
                //k.AddRange(Inspector.Controls as IEnumerable<Control>);
            }
            catch { }

            for (int i = 0; i < k.Count; i++)
            {
                var c = k[i];
                Type t = c.GetType();
                bool fi = c.Tag is FieldInfo;


                #region Types
                if (t == typeof(BaseInputField))
                {
                    var ipf = (BaseInputField)c;

                    if (!ipf.Value.Focused)
                    {
                        object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                        ipf.Value.Text = val == null ? "" : val.ToString();
                    }
                }
                else if (t == typeof(ColorInputField))
                {
                    var ipf = (ColorInputField)c;

                    object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                    if (!ipf.Value.Focused)
                    {
                        ipf.Value.Color = (Color)val;
                    }

                    if (!ipf.Value2.Focused)
                    {
                        ipf.Value2.Color = (Color)val;
                    }
                }
                else if (t == typeof(ExtendedColorInputField))
                {
                    var ipf = (ExtendedColorInputField)c;

                    object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                    if (!ipf.Value.Focused)
                    {
                        ipf.Value.Color = (Color)val;
                    }

                    if (!ipf.Value2.Focused)
                    {
                        ipf.Value2.Color = (Color)val;
                    }
                }
                else if (t == typeof(ButtonInputField))
                {
                    var ipf = (ButtonInputField)c;

                    object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                    //ipf.Action.Text = val.ToString();
                }
                else if (t == typeof(BoolInputField))
                {
                    var ipf = (BoolInputField)c;
                    if (!ipf.Value.Focused)
                    {
                        object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);
                        ipf.Value.Checked = bool.Parse(val.ToString());
                    }
                }
                else if (t == typeof(NumberInputField))
                {
                    var ipf = (NumberInputField)c;
                    if (!ipf.Value.Focused)
                    {
                        object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                        ipf.Value.Value = decimal.Parse(val.ToString());
                    }
                }
                else if (t == typeof(VectorInputField))
                {
                    var ipf = (VectorInputField)c;
                    if (!ipf.Value1.Focused)
                    {
                        object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                        ipf.Value1.Value = decimal.Parse(((Vector2)val).X.ToString());
                    }

                    if (!ipf.Value2.Focused)
                    {
                        object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                        ipf.Value2.Value = decimal.Parse(((Vector2)val).Y.ToString());
                    }
                }
                else if (t == typeof(EnumInputField))
                {
                    var ipf = (EnumInputField)c;

                    if (!ipf.Value.Focused)
                    {
                        object val = fi ? ((FieldInfo)ipf.Tag).GetValue(ipf.ValueObject) : ((PropertyInfo)ipf.Tag).GetValue(ipf.ValueObject);

                        ipf.Value.SelectedItem = val;
                    }
                }
                #endregion
            }
        }

        private void AssetHome_Click(object sender, EventArgs e)
        {
            if (currentAssetDirectory != homeAssetDirectory)
            {
                LoadAssetFolder(homeAssetDirectory);
            }
        }

        private void canvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create Canvas
            GameObject go = new GameObject(name: "New Canvas");
            var tn = Hierarchy.SelectedNode;
            if (tn != null)
            {
                go.SetParent((GameObject)tn.Tag);
                HierarchyItems[go.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[go.GetInspectorID()];
                while (node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }

            go.AddComponent<Canvas>();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create Text
            GameObject go = new GameObject(name: "New Text");
            var tn = Hierarchy.SelectedNode;
            if (tn != null)
            {
                go.SetParent((GameObject)tn.Tag);
                HierarchyItems[go.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[go.GetInspectorID()];
                while (node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }

            go.AddComponent<Wingine.UI.TextRenderer>();
        }

        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create Button
            GameObject go = new GameObject(name: "New Button");
            var tn = Hierarchy.SelectedNode;
            if (tn != null)
            {
                go.SetParent((GameObject)tn.Tag);
                HierarchyItems[go.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[go.GetInspectorID()];
                while (node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }

            go.AddComponent<Wingine.UI.Button>();

            GameObject got = new GameObject(name: "Text");
            var tnt = HierarchyItems[go.GetInspectorID()];

            if (tnt != null)
            {
                got.SetParent((GameObject)tnt.Tag);
                //HierarchyItems[got.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[got.GetInspectorID()];
                while (node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }

            got.AddComponent<Wingine.UI.TextRenderer>().Text = "New Button";
        }

        private void emptyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Create Empty GameObject
            GameObject go = new GameObject();
            var tn = Hierarchy.SelectedNode;
            if (tn != null)
            {
                go.SetParent((GameObject)tn.Tag);
                HierarchyItems[go.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[go.GetInspectorID()];
                while (node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }
        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create Camera
            GameObject go = new GameObject(name: "New Camera");
            var tn = Hierarchy.SelectedNode;
            if (tn != null)
            {
                go.SetParent((GameObject)tn.Tag);
                HierarchyItems[go.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[go.GetInspectorID()];
                while (node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }

            go.AddComponent<Wingine.Camera>();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Hierarchy.SelectedNode != null)
                {
                    ((GameObject)Hierarchy.SelectedNode.Tag).Destroy();
                    ClearInspector();
                }
            }
            catch { }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadHierarchy();
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameObject go = (GameObject)Hierarchy.SelectedNode?.Tag;
            if (go != null)
            {
                LoadHierarchy(fully: true, partials: new List<GameObject>() { go.Duplicate() }); // SUBJECTED TO CHANGE
                HierarchyItems[go.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[go.GetInspectorID()];
                while (node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }
        }

        private void PlayStopTSB_Click(object sender, EventArgs e)
        {
            StartStopApp();
        }

        private void emptyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Scene();
            SceneManager.LoadLastScene();
        }

        private void SceneMenuTSB_Click(object sender, EventArgs e)
        {
            var lsm = new LoadSceneMenu();

            if (Runner.App.CurrentScene != null)
            {
                lsm.View.SelectedNode = lsm.View.Nodes[Runner.App.CurrentScene.SceneIndex];
            }

            lsm.View.NodeMouseClick += (s, ex) =>
            {
                var scene = ((Scene)ex.Node.Tag);
                if (scene != Runner.App.CurrentScene)
                {
                    SceneManagement.SceneManager.LoadScene(scene.SceneIndex);
                }
            };
            lsm.ShowDialog();
        }

        private void Hierarchy_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            preventHierarchyNodeClick_Once = true;
            LoadGameObjectInspector(preSelectedObject as GameObject);
        }

        private void deleteCurrentSceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Runner.CurrentProject != null && Runner.App.CurrentScene != null)
            {
                Runner.CurrentProject?.Item3.Remove(Runner.App?.CurrentScene);
                SceneManager.LoadFirstScene();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AssetListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AssetListView.SelectedIndices.Count == 0) return;

            var sItem = AssetListView.Items[AssetListView.SelectedIndices[AssetListView.SelectedIndices.Count - 1]];

            if (sItem.Group == AssetListView.Groups[0])
            {
                LoadAssetFolder(sItem.Tag.ToString());
            }
        }

        private void AssetBack_Click(object sender, EventArgs e)
        {
            if (currentAssetDirectory != homeAssetDirectory)
            {
                LoadAssetFolder(Directory.GetParent(currentAssetDirectory).FullName);
            }
        }

        static void OpenDirectoryInFileExplorer(string directoryPath)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = directoryPath
            };

            Process.Start(startInfo);
        }

        private void showInFileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDirectoryInFileExplorer(currentAssetDirectory);
        }

        static void OpenFile(string filePath)
        {
            Process.Start(filePath);
        }
        private void AssetListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (AssetListView.SelectedIndices.Count == 0) return;

            var sItem = AssetListView.Items[AssetListView.SelectedIndices[AssetListView.SelectedIndices.Count - 1]];

            if (sItem.Group == AssetListView.Groups[1])
            {
                OpenFile(sItem.Tag.ToString());
            }
        }

        private void PixelEditor_TSB_Click(object sender, EventArgs e)
        {
            try
            {
                PixelEditor.PixelEditor editor = new PixelEditor.PixelEditor();
                editor.Show(this);
            }
            catch (TypeLoadException)
            {
                Debug.Write("Pixel Editor's DLL was not found!", Debug.DebugType.Error);
            }
        }

        private void debugRepeatToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Debug.CanRepeat = debugRepeatToolStripMenuItem.Checked;
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                exitToolStripMenuItem?.PerformClick();
            }
        }
        #endregion

        #region Saving and Loading
        string currentFile = "";
        string fileFilter = "Wingine Project File (*.wingine)|*.wingine";
        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentFile = "";
            Runner.CurrentProject = new Tuple<string, string, List<Scene>, Dictionary<string, object>>("Unnamed Project", DateTime.UtcNow.Ticks.ToString(), new List<Scene>(), new Dictionary<string, object>());
            LoadHierarchy(fully: true);
            ClearInspector();

        }

        public void Open(string proj, bool urgent = false, bool changePointer = true)
        {
            if (File.Exists(proj) && proj.EndsWith(".wingine"))
            {
                try
                {
                    Runner.CurrentProject = DataStore.ReadFromBinaryFile<Tuple<string, string, List<Scene>, Dictionary<string, object>>>(proj);

                    if (changePointer) currentFile = proj;
                    string nme = DateTime.Now.Ticks.ToString();

                    if (Runner.CurrentProject != null) nme = Runner.CurrentProject.Item1;

                    if (Runner.CurrentProject.Item3 == null || Runner.CurrentProject.Item3.Count == 0)
                    {
                        Runner.CurrentProject = new Tuple<string, string, List<Scene>, Dictionary<string, object>>(nme, DateTime.UtcNow.Ticks.ToString(), new List<Scene>(), new Dictionary<string, object>());
                        Runner.CurrentProject.Item3.Add(new Wingine.Scene());
                    }

                    Runner.App.CurrentScene = Runner.CurrentProject.Item3[0];
                    LoadHierarchy(fully: true);
                    ClearInspector();

                    Text = $"{(Runner.CurrentProject != null ? Runner.CurrentProject.Item1 + " - " : string.Empty)}Wingine";
                }
                catch
                {
                    Debug.Write($"Unable to load Wingine Project from '{proj}'", Debug.DebugType.Error);
                }
            }
            else
            {
                if (urgent) Open();
            }
        }

        public void Open()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = fileFilter;
            //ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Title = "Open Wingine Project";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Open(ofd.FileName);
            }
        }

        public void Save()
        {
            if (File.Exists(currentFile))
            {
                DataStore.WriteToBinaryFile(currentFile, Runner.CurrentProject);
            }
            else
            {
                SaveAs();
            }
        }

        public void SaveAs(string file = "", bool changePointer = true)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = fileFilter;
            sfd.Title = "Save Wingine Project As";

            string fname = file;

            if (string.IsNullOrWhiteSpace(file) && sfd.ShowDialog() == DialogResult.OK)
            {
                fname = sfd.FileName;
                DataStore.WriteToBinaryFile(fname, Runner.CurrentProject);
            }

            if (changePointer) currentFile = fname;
        }


        #endregion

        #region Building
        private void BuildGameTSB_Click(object sender, EventArgs e)
        {
            if (Runner.CurrentProject == null)
            {
                Debug.Write("No Project Found To Build!", Debug.DebugType.Error);
                return;
            }

            Save();

            var pfp = $"./{Runner.CurrentProject.Item1}.wingine_app";

            DataStore.WriteToBinaryFile(pfp, new CartageSave() { Game = Runner.CurrentProject });
            var et = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            var fp = Path.GetFullPath(pfp);

            Runner.Build(fp);
            /*
            Debug.Write($"Building '{Runner.CurrentProject.Item1}'...", Debug.DebugType.Editor);
            var st = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Save();

            DataStore.WriteToBinaryFile($"./{Runner.CurrentProject.Item1}.wingine_app", new CartageSave() { Game = Runner.CurrentProject });
            var et = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            var fp = Path.GetFullPath($"./{Runner.CurrentProject.Item1}.wingine_app");
            Debug.Write($"Building Completed in {et - st}ms!\nSee '{fp}' for finished build.", Debug.DebugType.Editor);
            */
            
        }
        #endregion

        #region Runtime
        public bool RunningApp = false;

        int returnSceneIndex;
        void RollBack()
        {
            Open(currentFile, changePointer: false);
            SceneManager.LoadScene(returnSceneIndex);


            //SceneManager.ReloadScene();
            if (SelectedObject != null)
            {
                LoadGameObjectInspector(SceneManager.CurrentScene.Get(((GameObject)SelectedObject)?.ID));
            }
        }


        void StopApp()
        {
            Runner.App?.Stop();
            Runner.App?.Hide();
            RunningApp = false;

            Runner.CurrentProject = null;
            Runner.App.CurrentScene = null;
            RollBack();

            //Runner.App?.RenderPlanes.Add(Scene);

            PlayStopTSB.Image = Properties.Resources.play2;
        }

        void StartApp()
        {
            Save();

            returnSceneIndex = Runner.App.CurrentScene.SceneIndex;

            Runner.InEditor = true;
            Runner.App.FormClosing += (s, e) =>
            {
                e.Cancel = true;
                StopApp();
            };

            //Runner.App?.RenderPlanes.Remove(Scene);

            Runner.App?.Start();
            Runner.App?.Show();
            RunningApp = true;

            PlayStopTSB.Image = Properties.Resources.stop2;
            if(clearOnPlayToolStripMenuItem.Checked) ClearConsole();
        }

        void StartStopApp()
        {
            if (!RunningApp)
            {
                if (Runner.App != null && Runner.App.CurrentScene != null)
                {
                    StartApp();
                }
                else
                {
                    Debug.Write(Runner.App == null ?
                        "Error Launching Application, Please restart the Editor!" :
                        "Error Launching Application, No Loaded Scene was found!",
                    Debug.DebugType.Error);
                }
            }
            else
            {
                if (Runner.App != null)
                {
                    StopApp();
                }
            }
        }

        #endregion

        #region Helper Funcs
        /*
         * Object Index = Parent Index + Node Index
         * No parent 
         *   0 | 1
         *   First Node
         *    0 | 1
         *    
         *   -> 0 + 0 = 0 | 1 + 1 = 2
         */
        public int GetObjectIndex(GameObject go)
        {
            int parentIndex = go.Parent != null ? GetObjectIndex(go.Parent) : 0;
            var node = HierarchyItems[go.GetInspectorID()];
            int nodeIndex = node.Index;

            return parentIndex + nodeIndex;
        }
        #endregion

    }
}