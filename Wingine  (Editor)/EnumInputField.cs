using System;
using System.Reflection;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class EnumInputField : UserControl
    {
        public object ValueObject;
        public EnumInputField()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
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

            var tval = (Enum)value;
            if (!Value.Focused) Value.SelectedText = tval.ToString();
        }
    }
}
