using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Wingine.UI;

namespace Wingine.Editor
{
    public partial class AddComponentMenu : Form
    {
        public static List<Type> Components = new List<Type>();

        static AddComponentMenu()
        {
            Components.Add(typeof(Camera));
            Components.Add(typeof(PixelRenderer));
            Components.Add(typeof(Canvas));
            Components.Add(typeof(Text));
            Components.Add(typeof(Player));
        }

        public AddComponentMenu()
        {
            InitializeComponent();

            foreach (var comp in Components)
            {
                View.Nodes.Add(comp.Name.AddSpacesToSentence()).Tag = comp;
            }
        }
    }
}
