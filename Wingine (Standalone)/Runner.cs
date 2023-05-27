using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wingine
{
    [Serializable]
    public class Runner
    {
        public static Application App { get; private set; }

        public static Tuple<string, List<Scene>> CurrentProject = new Tuple<string, List<Scene>>("[Unknown]", null);

        public static bool InEditor = false;
        
        static Runner()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            App = new Application();
        }

        public Runner()
        {

        }

        public void Show()
        {
            App.Show();
        }

        [STAThread]
        public static void Run()
        {
            System.Windows.Forms.Application.Run(App);
        }

        [STAThread]
        static void Main()
        {
            CurrentProject = DataStore.ReadFromBinaryFile<Tuple<string, List<Scene>>>(@"C:\Users\PC USER\Desktop\Debug.wingine");// Environment.GetCommandLineArgs()[1]);
            App.CurrentScene = CurrentProject.Item2[0];
            App.Text = CurrentProject.Item1;
            App.Start();
            Run();
        }
    }
}
