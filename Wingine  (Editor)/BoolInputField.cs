using System;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class BoolInputField : UserControl
    {
        public object ValueObject;

        public BoolInputField()
        {
            InitializeComponent();
        }

        private void Value_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
