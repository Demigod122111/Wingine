using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.IO;
using System.Linq;
using System.Windows;

namespace Wingine
{

    [Serializable]
    public class Runner
    {
        public static Application App { get; private set; }

        public static Tuple<
            string, // Project Name
            string, // Project ID
            string, // Application Title
            List<Scene>, // Project Scenes
            Dictionary<string, object> // PlayerPrefs
            > CurrentProject = new Tuple<string, string, string, List<Scene>, Dictionary<string, object>>("", DateTime.UtcNow.Ticks.ToString(), "Wingine Application",null, null);


        public static void SetCurrentProjectName(string name)
        {
            CurrentProject = new Tuple<string, string, string, List<Scene>, Dictionary<string, object>>(name, CurrentProject.Item2, CurrentProject.Item3, CurrentProject.Item4, CurrentProject.Item5);
        }

        public static void SetCurrentProjectID(string id)
        {
            CurrentProject = new Tuple<string, string, string, List<Scene>, Dictionary<string, object>>(CurrentProject.Item1, id, CurrentProject.Item3, CurrentProject.Item4, CurrentProject.Item5);
        }

        public static void SetCurrentApplicationTitle(string title)
        {
            CurrentProject = new Tuple<string, string, string, List<Scene>, Dictionary<string, object>>(CurrentProject.Item1, CurrentProject.Item2, title, CurrentProject.Item4, CurrentProject.Item5);
        }

        public static void SetCurrentProjectScenes(List<Scene> scenes)
        {
            CurrentProject = new Tuple<string, string, string, List<Scene>, Dictionary<string, object>>(CurrentProject.Item1, CurrentProject.Item2, CurrentProject.Item3, scenes, CurrentProject.Item5);
        }

        public static void SetCurrentPlayerPrefs(Dictionary<string, object> playerPrefs)
        {
            CurrentProject = new Tuple<string, string, string, List<Scene>, Dictionary<string, object>>(CurrentProject.Item1, CurrentProject.Item2, CurrentProject.Item3, CurrentProject.Item4, playerPrefs);
        }

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
            App.Text = CurrentProject.Item3;
            App.Show();
        }

        [STAThread]
        public static async void Run()
        {
            await Task.Run(() => { System.Windows.Forms.Application.Run(App); });
        }

        public static void BuildMain()
        {
            string file = Path.GetFullPath("./" + Path.GetFileNameWithoutExtension(System.Windows.Forms.Application.ExecutablePath) + ".wingine_app");
            if (File.Exists(file))
            {
                var dfba = DataStore.ReadFromBinaryFile<CartageSave>(file);
                CurrentProject = dfba.Game;
            }
            else MessageBox.Show($"Specified File '{file}' was not found!");

            App.CurrentScene = CurrentProject.Item4[0];
            App.Text = CurrentProject.Item3;


            App.Start();
            System.Windows.Forms.Application.Run(App);
        }

        [STAThread]
        static void Main()
        {
            if (Environment.GetCommandLineArgs()[1].EndsWith(".wingine"))
            {
                CurrentProject = DataStore.ReadFromBinaryFile<Tuple<string, string, string, List<Scene>, Dictionary<string, object>>>(Environment.GetCommandLineArgs()[1]);
            }
            else if (Environment.GetCommandLineArgs()[1].EndsWith(".wingine_app"))
            {
                var dfba = DataStore.ReadFromBinaryFile<CartageSave>(Environment.GetCommandLineArgs()[1]);
                CurrentProject = dfba.Game;
            }

            App.CurrentScene = CurrentProject.Item4[0];
            App.Text = CurrentProject.Item3;

            App.Start();
            System.Windows.Forms.Application.Run(App);
        }

        public static void Build(string app_file)
        {
            Task.Run(() =>
            {
                //string buildCode = $"using Wingine;class BuildRunner{{public static void Main(){{new BuildRunner();}}BuildRunner(){{Runner.BuildMain(@\"{app_file}\");}}}}";
                string buildCode = $"using Wingine;class BuildRunner{{public static void Main(){{new BuildRunner();}}BuildRunner(){{Runner.BuildMain();}}}}";

                Debug.Write($"Building '{Runner.CurrentProject.Item1}'...", Debug.DebugType.Editor);
                var st = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

                var asm = Assembly.GetExecutingAssembly();

                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                ICodeCompiler icc = codeProvider.CreateCompiler();

                Directory.CreateDirectory($"./{Runner.CurrentProject.Item1}_BUILD/");
                string Output = $"./{Runner.CurrentProject.Item1}_BUILD/{Runner.CurrentProject.Item1}.exe";

                string appFile = $"./{Runner.CurrentProject.Item1}_BUILD/{Runner.CurrentProject.Item1}.wingine_app";
                string dllFile = $"./{Runner.CurrentProject.Item1}_BUILD/Wingine (Standalone).dll";

                try
                {
                    if (File.Exists(appFile)) File.Delete(appFile);
                    if (File.Exists(dllFile)) File.Delete(dllFile);

                    File.Move(app_file, appFile);
                    File.Copy("./Wingine (Standalone).dll", dllFile);
                }
                catch (Exception ex)
                {
                    var et = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    Debug.Write($"Building Failed in {et - st}ms!\nReason: {ex.Message}", Debug.DebugType.Editor);
                }

                CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateExecutable = true;
                parameters.CompilerOptions = "/target:winexe /optimize";
                //parameters.CompilerOptions = @"";

                parameters.ReferencedAssemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies().Select(a => a.Location).ToArray());
                parameters.ReferencedAssemblies.Add(typeof(Runner).Assembly.Location);

                List<string> asms = new List<string>();
                for (int i = 0; i < parameters.ReferencedAssemblies.Count; i++)
                {
                    asms.Add(parameters.ReferencedAssemblies[i]);
                }
                //MessageBox.Show(string.Join("\n", asms));
                parameters.OutputAssembly = Output;
                parameters.MainClass = "BuildRunner";
                CompilerResults results = icc.CompileAssemblyFromSource(parameters, buildCode);

                if (results.Errors.Count > 0)
                {
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        Debug.Write(
                                    "Line number " + CompErr.Line +
                                    ", Error Number: " + CompErr.ErrorNumber +
                                    ", '" + CompErr.ErrorText + ";" +
                                    Environment.NewLine + Environment.NewLine, Debug.DebugType.Error);
                    }

                    var et = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    Debug.Write($"Building Failed in {et - st}ms!", Debug.DebugType.Editor);
                }
                else
                {
                    var et = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    Debug.Write($"Building Completed in {et - st}ms!\n{Path.GetFullPath(Output)}", Debug.DebugType.Editor);
                }
            });
        }
    }

    [Serializable]
    public class CartageSave
    {
        public Tuple<
            string,
            string,
            string,
            List<Scene>,
            Dictionary<string, object>
            > Game;
    }
}
