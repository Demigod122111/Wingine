using System.Windows.Forms;

namespace Wingine.Editor
{
    public class CustomNumericUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            Text = Value.ToString("0." + new string('#', DecimalPlaces));
        }
    }
}
