using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wingine
{
    [Serializable]
    public class Runner
    {
        public static Application App { get; private set; }

        public static Tuple<
            string, // Project Name
            string, // Project ID
            List<Scene>, // Project Scenes
            Dictionary<string, object> // PlayerPrefs
            > CurrentProject = new Tuple<string, string, List<Scene>, Dictionary<string, object>>("", DateTime.UtcNow.Ticks.ToString(), null, null);





        public static bool InEditor = false;
        public static bool UnderlyingDebug = false;

        static Runner()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            App = new Application();
            Input.Init();
        }

        public Runner()
        {

        }

        public void Show()
        {
            App.Show();
        }

        [STAThread]
        public static async void Run()
        {
            await Task.Run(() => { System.Windows.Forms.Application.Run(App); });


        }

        [STAThread]
        static void Main()
        {
            if (Environment.GetCommandLineArgs()[1].EndsWith(".wingine"))
            {
                CurrentProject = DataStore.ReadFromBinaryFile<Tuple<string, string, List<Scene>, Dictionary<string, object>>>(Environment.GetCommandLineArgs()[1]);
            }
            else if (Environment.GetCommandLineArgs()[1].EndsWith(".wingine_app"))
            {
                var dfba = DataStore.ReadFromBinaryFile<CartageSave>(Environment.GetCommandLineArgs()[1]);
                CurrentProject = dfba.Game;
            }

            App.CurrentScene = CurrentProject.Item3[0];
            App.Text = CurrentProject.Item1;


            App.Start();
            System.Windows.Forms.Application.Run(App);
        }
    }

    [Serializable]
    public class CartageSave
    {
        public Tuple<
            string,
            string,
            List<Scene>,
            Dictionary<string, object>
            > Game;
    }
}
