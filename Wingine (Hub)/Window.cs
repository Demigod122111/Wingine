using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Wingine;
using System.Diagnostics;
using System.Reflection;

namespace Wingine.Hub
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            string projName = tb_proj_name.Text.Trim();
            string projNameFS = projName;

            foreach (var ic in Path.GetInvalidFileNameChars())
            {
                projNameFS = projNameFS.Replace(ic.ToString(), "");
            }

            var projDir = Path.GetFullPath(tb_proj_dir.Text);
            Directory.CreateDirectory(projDir);

            List<Scene> scenes = null;

            var selectedTemplate = cb_proj_type.Text.ToLower();

            Scene ds;

            switch (selectedTemplate)
            {
                case "empty":
                    scenes = new List<Scene>();
                    ds = new Scene();
                    scenes.Add(ds);
                    break;
                case "default":
                    scenes = new List<Scene>();
                    ds = new Scene();
                    scenes.Add(ds);

                    GameObject mainCam = new GameObject(name: "Main Camera");
                    mainCam.Tag = "MainCamera";
                    mainCam.AddComponent<Camera>();

                    ds.AddGameObject(mainCam);

                    break;
                default:
                    break;
            }

            Tuple<
            string, // Project Name
            string, // Project ID
            string, // Application Title
            List<Scene>, // Project Scenes
            Dictionary<string, object> // PlayerPrefs
            > CreationProject = 
            new Tuple<string, string, string, List<Scene>, Dictionary<string, object>>(projName, DateTime.UtcNow.Ticks.ToString(), "Wingine Application", scenes, new Dictionary<string, object>());

            var projFile = $"{projNameFS}.wingine";
            projFile = $"{projDir}\\{projFile}";

            if (File.Exists(projFile))
            {
                MessageBox.Show($"Unable To Create Project: \n{projFile}");
            }
            else
            {
                DataStore.WriteToBinaryFile(projFile, CreationProject);

                try
                {
                    File.AppendAllText(projects, $"\n{projFile}");
                    LoadProjects();
                }
                catch { }

                LoadEngine();
                Process.Start(new ProcessStartInfo($"\"{tb_engine.Text}\"", $"\"{projFile}\""));
                Close();
            }
        }

        private void tb_proj_dir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Directory.Exists(Path.GetFullPath(tb_proj_dir.Text)) ? Path.GetFullPath(tb_proj_dir.Text) : Path.GetFullPath("C:/");

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                tb_proj_dir.Text = fbd.SelectedPath;

                try
                {
                    File.WriteAllText(pcf, tb_proj_dir.Text);
                }
                catch { }
            }
        }

        string projects = "";
        string pcf = "";
        string engineFile = "";

        private void Window_Load(object sender, EventArgs e)
        {
            cb_proj_type.SelectedIndex = 0;

            try
            {

                var df = Path.Combine(System.Windows.Forms.Application.LocalUserAppDataPath, "Wingine");
                Directory.CreateDirectory(df);

                pcf = $"{df}\\project creation directory.txt";

                if (File.Exists(pcf))
                {
                    var pth = Path.GetFullPath(File.ReadAllText(pcf));
                    if (File.Exists(pth))
                    {
                        tb_proj_dir.Text = pth;
                        File.WriteAllText(pcf, tb_proj_dir.Text);
                    }
                    else
                    {
                        File.WriteAllText(pcf, tb_proj_dir.Text);
                    }
                }
                else
                {
                    File.WriteAllText(pcf, tb_proj_dir.Text);
                }

                projects = $"{df}\\projects.txt";

                LoadProjects();
            }
            catch { }

            LoadEngine();
        }

        void LoadEngine()
        {
            engineFile = Path.GetFullPath("./Wingine.Hub.Wingine.exe");
            ResourceReader.CreateFileFromResource("Wingine.Hub.Wingine.exe", engineFile);
            tb_engine.Text = engineFile;

            ResourceReader.CreateFileFromResource("Wingine.Hub.Costura.dll", Path.GetFullPath("./Costura.dll"));
            ResourceReader.CreateFileFromResource("Wingine.Hub.Wingine (Standalone).dll", Path.GetFullPath("./Wingine (Standalone).dll"));
        }

        public static class ResourceReader
        {
            // to read the file as a Stream
            public static Stream GetResourceStream(string resourceName)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
                return resourceStream;
            }

            // to save the resource to a file
            public static void CreateFileFromResource(string resourceName, string path)
            {
                Stream resourceStream = GetResourceStream(resourceName);
                if (resourceStream != null)
                {
                    using (Stream input = resourceStream)
                    {
                        using (Stream output = File.Create(path))
                        {
                            input.CopyTo(output);
                            output.Close();
                            output.Dispose();
                        }
                        input.Close();
                        input.Dispose();
                    }
                }
            }
        }

        void LoadProjects()
        {
            lb_projects.Items.Clear();

            if (!File.Exists(projects)) File.WriteAllText(projects, "");

            List<string> items = new List<string>();

            foreach (var proj in File.ReadAllLines(projects))
            {
                if (!string.IsNullOrEmpty(proj.Trim()))
                {
                    if (File.Exists(proj))
                    {
                        items.Add(proj);
                    }
                }
            }

            File.WriteAllText(projects, string.Join("\n", items));

            items.Reverse();

            lb_projects.Items.AddRange(items.ToArray());
        }

        private void btn_open_dir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", tb_proj_dir.Text);
        }

        private void tb_engine_Click(object sender, EventArgs e)
        {
            return;
        }

        private void lb_projects_DoubleClick(object sender, EventArgs e)
        {
            if(lb_projects.SelectedIndex >= 0)
            {
                LoadEngine();
                Process.Start(new ProcessStartInfo($"\"{tb_engine.Text}\"", $"\"{lb_projects.Items[lb_projects.SelectedIndex]}\""));
                Close();
            }
        }
    }
}
