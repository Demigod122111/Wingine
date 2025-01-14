﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wingine.SceneManagement;
using XCoolForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wingine.Editor
{
    public partial class Window : XCoolForm.XCoolForm
    {
        public static Runner Runner = new Runner();

        public int TARGET_FPS = 240;

        object preSelectedObject;
        object SelectedObject;

        bool preventHierarchyNodeClick_Once = false;

        #region Hierarchy

        Dictionary<string, TreeNode> HierarchyItems = new Dictionary<string, TreeNode>();
        Dictionary<TreeNode, bool> HierarchyItemsExpansion = new Dictionary<TreeNode, bool>();

        public void ReloadHierarchyObject(GameObject go)
        {
            LoadHierarchy(true);
        }

        public async void LoadHierarchy(bool fully = true, List<GameObject> partials = null)
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
                }
            }

            async void LoadGameObjects(List<GameObject> gos)
            {
                List<GameObject> Unloaded = new List<GameObject>();

                for (int i = 0; i < gos.Count; i++)
                {
                    var go = gos[i];

                    if (go.Parent != null)
                    {
                        string piid = go.Parent.GetInspectorID();

                        if (!string.IsNullOrWhiteSpace(piid) && HierarchyItems.ContainsKey(piid))
                        {
                            AddGameObject(go, HierarchyItems[piid]);
                        }
                        else
                        {
                            Unloaded.Add(go);
                        }
                    }
                    else
                    {
                        AddGameObject(go, null);
                    }
                }

                if (Unloaded.Count > 0)
                {
                    var task = new Task(() => { LoadGameObjects(Unloaded); });
                    task.RunSynchronously();
                    await Task.Run(() => { while (!task.IsCompleted) { } });
                }
            }

            if (Runner.App.CurrentScene != null)
            {
                var task = new Task(() => { LoadGameObjects(fully == true ? Runner.App.CurrentScene.GameObjects : partials); });
                task.RunSynchronously();
                await Task.Run(() => { while (!task.IsCompleted) { } });
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

                if ((object)comp == (object)go.Transform)
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

                var props = comp.GetType().GetProperties();

                for (int i = 0; i < props.Length; i++)
                {
                    var member = props[i];

                    if (member.GetSetMethod() == null || !member.GetSetMethod().IsPublic) continue;

                    Type t = member.PropertyType;

                    if (Attribute.IsDefined(member, typeof(Wingine.HideInInspector)))
                    {
                        continue;
                    }

                    #region Types

                    if (t == typeof(Color))
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
                                member.SetValue(comp, (object)inputField.Value.Text);
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }
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

                var fields = comp.GetType().GetFields();
                for (int i = 0; i < fields.Length; i++)
                {
                    var member = fields[i];

                    if (!member.IsPublic || member.IsStatic || member.IsInitOnly) continue;

                    Type t = member.FieldType;

                    if (Attribute.IsDefined(member, typeof(Wingine.HideInInspector)))
                    {
                        continue;
                    }

                    #region Types
                    if (t == typeof(Color))
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
                                member.SetValue(comp, (object)inputField.Value.Text);
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.InnerException.Message, Debug.DebugType.Error);
                            }
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
                InspectorItemHeight = c.Height;
                NewPos = new Point(0, c.Location.Y + InspectorItemHeight + InspectorItemPadding);
            }


            AddComponent.Title.Text = "";
            AddComponent.Action.Text = "Add Component";
            ACEH = (s, e) =>
            {
                AddComponentMenu ACM = new AddComponentMenu();

                ACM.View.NodeMouseClick += (s1, e1) =>
                {
                    ((GameObject)SelectedObject).AddComponent(e1.Node.Tag as Type);
                    ACM.Close();
                    LoadGameObjectInspector((GameObject)SelectedObject);
                };

                ACM.ShowDialog();
            };
            AddComponent.Action.Click += ACEH;
            AddItemToInspector(AddComponent.Action);

            Inspector.Visible = true;

        }

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
            this.TitleBar.TitleBarCaption = $"{Runner.CurrentProject?.Item1} : Wingine";

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

            };

            Wingine.Debug.DebugEventOccured += (msg, type) =>
            {
                var tmsg = $"[{type} | {DateTime.Now.TimeOfDay}]: {msg}\n";

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

            PlayStopTSB.Image = RunningApp ? global::Wingine.Editor.Properties.Resources.stop2 : global::Wingine.Editor.Properties.Resources.play2;


            if (Runner.App.CurrentScene != null && !Runner.App.IsRunning) Runner.App.Render();

            if(Runner.App.CurrentScene == null)
            {
                if(Runner.CurrentProject?.Item2?.Count != 0)
                {
                    SceneManagement.SceneManager.LoadFirstScene();
                }
            }

            if (Runner.App.CurrentScene == null ||
                Runner.CurrentProject == null ||
                Runner.CurrentProject.Item2 == null ||
                Runner.CurrentProject.Item2.Count == 0)
            {
                HierarchyUpdater.Enabled = false;
                InspectorUpdater.Enabled = false;
            }
            else
            {
                HierarchyUpdater.Enabled = true;
                InspectorUpdater.Enabled = true;
            }
        }

        private void Window_Load(object sender, EventArgs e)
        {
            LoadAssetFolder(homeAssetDirectory);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.Text = "";
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
            if(HierarchyItemsExpansion.ContainsKey(e.Node) && e.Node.IsExpanded != HierarchyItemsExpansion[e.Node])
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

        async void UpdateInspector()
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
                k.AddRange(Inspector.Controls as IEnumerable<Control>);
            }
            catch { }

            for (int i = 0; i < k.Count; i++)
            {
                var c = k[i];
                Type t = c.GetType();
                bool fi = ((Control)c).Tag is FieldInfo;


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

                    ipf.Action.Text = val.ToString();
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
        private void gameObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameObject go = new GameObject();
            var tn = Hierarchy.SelectedNode;
            if (tn != null)
            {
                go.SetParent((GameObject)tn.Tag);
                HierarchyItems[go.GetInspectorID()].EnsureVisible();

                TreeNode node = HierarchyItems[go.GetInspectorID()];
                while(node != null)
                {
                    HierarchyItemsExpansion[node] = node.IsExpanded;
                    node = node.Parent;
                }
            }
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

        public bool RunningApp = false;

        int returnSceneIndex;
        List<Scene> rollbackObject;

        void RollBack()
        {
            Runner.CurrentProject = new Tuple<string, List<Scene>>(Runner.CurrentProject.Item1, rollbackObject);
            Runner.App.CurrentScene = Runner.CurrentProject.Item2[returnSceneIndex];
            reloadToolStripMenuItem.PerformClick();

            ClearInspector();
            LoadHierarchy();
        }

        private void PlayStopTSB_Click(object sender, EventArgs e)
        {
            if (!RunningApp)
            {
                rollbackObject = Runner.CurrentProject.Item2;
                returnSceneIndex = SceneManager.CurrentSceneIndex;

                if (Runner.App != null && Runner.App.CurrentScene != null)
                {
                    Runner.InEditor = true;
                    Runner.App?.Start();
                    Runner.App?.Show();
                    RunningApp = true;

                    Runner.App.FormClosing += (s, se) =>
                    {
                        RunningApp = false;
                        RollBack();
                    };
                }
                else
                {
                    Debug.Write(Runner.App == null ? "Error Launching Application, Please restart the Editor!" : "Error Launching Application, No Loaded Scene was found!", Debug.DebugType.Error);
                }
            }
            else
            {
                if (Runner.App != null)
                {
                    Runner.App?.Stop();
                    Runner.App?.Hide();
                    RunningApp = false;
                    RollBack();
                }
            }
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
                Runner.CurrentProject?.Item2.Remove(Runner.App?.CurrentScene);
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

        public void Open(string proj, bool urgent = false)
        {
            if (File.Exists(proj) && proj.EndsWith(".wingine"))
            {
                currentFile = proj;
                try
                {
                    Runner.CurrentProject = DataStore.ReadFromBinaryFile<Tuple<string, List<Scene>>>(currentFile);
                }
                catch
                {
                    Runner.CurrentProject = new Tuple<string, List<Scene>>("[Unknown]", null);
                }

                string nme = DateTime.Now.Ticks.ToString();

                if (Runner.CurrentProject != null) nme = Runner.CurrentProject.Item1;

                if (Runner.CurrentProject.Item2 == null || Runner.CurrentProject.Item2.Count == 0)
                {
                    Runner.CurrentProject = new Tuple<string, List<Scene>>(nme, new List<Scene>());
                    Runner.CurrentProject.Item2.Add(new Wingine.Scene());
                }

                Runner.App.CurrentScene = Runner.CurrentProject.Item2[0];
                LoadHierarchy(fully: true);
                ClearInspector();
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
                DataStore.WriteToBinaryFile<Tuple<string, List<Scene>>>(currentFile, Runner.CurrentProject);
            }
            else
            {
                SaveAs();
            }
        }

        public void SaveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = fileFilter;
            //sfd.InitialDirectory = Environment.CurrentDirectory;
            sfd.Title = "Save Wingine Project As";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentFile = sfd.FileName;
                DataStore.WriteToBinaryFile<Tuple<string, List<Scene>>>(currentFile, Runner.CurrentProject);
            }
        }

        #endregion

    }
}