using System;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class ExtendedColorInputField : UserControl
    {
        public object ValueObject;

        public ExtendedColorInputField()
        {
            InitializeComponent();
        }

        private void Value2_ColorChanged(object sender, EventArgs e)
        {
            Value.Color = Value2.Color;
        }

        private void Value_ColorChanged(object sender, EventArgs e)
        {
            Value2.Color = Value.Color;
        }
    }
}
