using System;
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
    }
}
