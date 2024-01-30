using System;
using System.Drawing;
using System.Reflection;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Tag == null) return;
            object value = null;

            if (Tag is PropertyInfo)
            {
                value = (Tag as PropertyInfo).GetValue(ValueObject);
            }
            else if (Tag is FieldInfo)
            {
                value = (Tag as FieldInfo).GetValue(ValueObject);
            }
            else return;

            var tval = (Color)value;
            if (!Value.Focused) Value.Color = tval;
            if (!Value2.Focused) Value2.Color = tval;
        }
    }
}
