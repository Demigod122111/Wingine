using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class ComponentMenu : Form
    {
        internal static List<Type> Components = new List<Type>();

        static ComponentMenu()
        {
            // BUILT-IN
            Add(typeof(Wingine.Camera));
            Add(typeof(Wingine.PixelRenderer));
            Add(typeof(Wingine.Script));
            Add(typeof(Wingine.PhysicsBody));
            Add(typeof(Wingine.Collider));
            Add(typeof(Wingine.UI.Canvas));
            Add(typeof(Wingine.UI.TextRenderer));
            Add(typeof(Wingine.UI.Button));
            //Add(typeof(Wingine.AudioSource));
        }

        public ComponentMenu()
        {
            InitializeComponent();

            foreach (var comp in Components)
            {
                var n = comp.Name.AddSpacesToSentence();
                var v = View.Nodes.Add(n);

                v.Name = n;
                v.Tag = comp;
            }

            View.Sort();
        }

        public static void Add(Type componentType)
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
                Components.Add(componentType);
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
                if (type.IsEquivalentTo(c)) return true;
            }

            return false;
        }
    }
}
