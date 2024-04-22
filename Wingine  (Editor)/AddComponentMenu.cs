using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace Wingine.Editor
{
    public partial class ComponentMenu : Form
    {
        internal static List<Tuple<string, Type>> Components = new List<Tuple<string, Type>>();

        static ComponentMenu()
        {
            // BUILT-IN
            Add("Basic", typeof(Wingine.Camera));

            Add("Rendering", typeof(Wingine.PixelRenderer));
            Add("Rendering", typeof(Wingine.SpriteRenderer));


            Add("Scripting", typeof(Wingine.Script));


            Add("Physics", typeof(Wingine.PhysicsBody));


            Add("UI", typeof(Wingine.UI.Canvas));
            Add("UI", typeof(Wingine.UI.TextRenderer));
            Add("UI", typeof(Wingine.UI.Button));
            
            Add("Media", typeof(Wingine.Audio.AudioSource));
            Add("Media", typeof(Wingine.Video.VideoPlayer));
        }

        Dictionary<string, TreeNode> Categories = new Dictionary<string, TreeNode>();
        public ComponentMenu()
        {
            InitializeComponent();

            for (int i = 0; i < Components.Count; i++)
            {
                var comp = Components[i];

                if (!Categories.ContainsKey(comp.Item1))
                {
                    var n = comp.Item1.AddSpacesToSentence();
                    var v = View.Nodes.Add(n);

                    v.Name = n;
                    v.ForeColor = Color.Cyan;
                    v.Tag = null;

                    Categories[comp.Item1] = v;
                }
            }

            foreach (var comp in Components)
            {
                var n = comp.Item2.Name.AddSpacesToSentence();
                var v = Categories[comp.Item1].Nodes.Add(n);

                v.Name = n;
                v.Tag = comp.Item2;
            }

            View.Sort();
        }

        public static void Add(string category, Type componentType)
        {
            object resolve = Activator.CreateInstance(componentType);
            bool valid = false;


            valid = valid || (
                resolve is MonoBehaviour ||
                resolve is IComponent ||
                resolve.GetType() == typeof(IComponent) ||
                resolve.GetType() == typeof(MonoBehaviour) ||
                resolve.GetType().IsSubclassOf(typeof(MonoBehaviour)) ||
                resolve.GetType().IsSubclassOf(typeof(IComponent))
            );


            if (!valid)
            {
                Debug.Write($"Cannot Add Type `{componentType}`. Type must be/derive from a IComponent or MonoBehaviour.", Debug.DebugType.Error);
                return;
            }

            if (!Has(componentType))
            {
                Components.Add(new Tuple<string, Type>(category, componentType));
            }
            else
            {
                Debug.Write($"Type `{componentType}` already exists in the Component Menu.", Debug.DebugType.Warning);
            }
        }

        public static bool Has(Type type)
        {
            foreach (var c in Components)
            {
                if (type.IsEquivalentTo(c.Item2)) return true;
            }

            return false;
        }
    }
}
