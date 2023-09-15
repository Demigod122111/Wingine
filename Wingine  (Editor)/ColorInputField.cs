using System;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class ColorInputField : UserControl
    {
        public object ValueObject;

        public ColorInputField()
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
