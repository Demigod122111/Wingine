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
                    foreach (var comp in Runner.CurrentProject?.Item3)
                    {
                        View.Nodes.Add($"({comp.SceneIndex}) - {comp}").Tag = comp;
                    }
                }
            }
        }
    }
}
