using System.Reflection;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class VectorInputField : UserControl
    {
        public object ValueObject;

        public VectorInputField()
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

            var tval = (Vector2)value;
            if (!Value1.Focused) Value1.Value = (decimal)tval.X;
            if (!Value2.Focused) Value2.Value = (decimal)tval.Y;
        }
    }
}
