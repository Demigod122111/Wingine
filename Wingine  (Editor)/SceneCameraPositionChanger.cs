using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class SceneCameraPositionChanger : Form
    {
        public SceneCameraPositionChanger()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void SceneCameraPositionChanger_Load(object sender, EventArgs e)
        {
            Value.Title.Text = "Scene Camera Position";
        }
    }
}
