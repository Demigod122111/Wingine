using System.Windows.Forms;

namespace Wingine.Editor
{
    public partial class LoadSceneMenu : Form
    {
        public LoadSceneMenu()
        {
            InitializeComponent();

            if (Runner.CurrentProject != null)
            {
                if (Runner.CurrentProject?.Item3 == null)
                {
                    Debug.Write("Error Probing Scenes!", Debug.DebugType.Error);
                }
                else
                {
                    foreach (var scene in Runner.CurrentProject?.Item3)
                    {
                        View.Nodes.Add($"[{scene.SceneIndex}] {scene.Name}").Tag = scene;
                    }
                }
            }
        }

        void NameSceneNodes()
        {
            for (int i = 0; i < View.Nodes.Count; i++)
            {
                var node = View.Nodes[i];
                var scene = (Scene)node.Tag;
                node.Text = $"[{scene.SceneIndex}] {scene.Name}";
            }
            
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if(View.SelectedNode == null)
            {
                btn_down.Enabled = false;
                btn_up.Enabled = false;
            }
            else
            {
                if (View.SelectedNode == View.Nodes[0] && View.Nodes.Count == 1)
                {
                    btn_down.Enabled = false;
                    btn_up.Enabled = false;
                }
                else if(View.SelectedNode == View.Nodes[View.Nodes.Count - 1])
                {
                    btn_down.Enabled = false;
                    btn_up.Enabled = true;
                }
                else if (View.SelectedNode == View.Nodes[0])
                {
                    btn_down.Enabled = true;
                    btn_up.Enabled = false;
                }
                else
                {
                    btn_down.Enabled = true;
                    btn_up.Enabled = true;
                }
            }
        }
        private void btn_up_Click(object sender, System.EventArgs e)
        {
            var node = View.SelectedNode;
            int index = View.Nodes.IndexOf(node);
            node.Remove();
            View.Nodes.Insert(index - 1, node);

            var scene = (Scene)node.Tag;
            var sindex = Runner.CurrentProject.Item3.IndexOf(scene);
            Runner.CurrentProject.Item3.Remove(scene);
            Runner.CurrentProject.Item3.Insert(sindex - 1, scene);

            NameSceneNodes();
        }

        private void btn_down_Click(object sender, System.EventArgs e)
        {
            var node = View.SelectedNode;
            int index = View.Nodes.IndexOf(node);
            node.Remove();
            View.Nodes.Insert(index + 1, node);

            var scene = (Scene)node.Tag;
            var sindex = Runner.CurrentProject.Item3.IndexOf(scene);
            Runner.CurrentProject.Item3.Remove(scene);
            Runner.CurrentProject.Item3.Insert(sindex + 1, scene);

            NameSceneNodes();
        }
    }
}
