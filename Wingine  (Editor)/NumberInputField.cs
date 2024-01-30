using System.Reflection;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class NumberInputField : UserControl
    {
        public object ValueObject;

        public NumberInputField()
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

            var tval = double.Parse(value.ToString());
            if (!Value.Focused) Value.Value = (decimal)tval;
        }
    }

}
