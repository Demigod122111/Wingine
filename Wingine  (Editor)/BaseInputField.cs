using System;
using System.Reflection;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class BaseInputField : UserControl
    {
        public object ValueObject;

        public BaseInputField()
        {
            InitializeComponent();
        }

        private void Value_TextChanged(object sender, EventArgs e)
        {

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

            var tval = (object)value;
            if (!Value.Focused) Value.Text = tval.ToString();
        }
    }
}
