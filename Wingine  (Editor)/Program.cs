using System;
using System.IO;
using System.Threading;
using Wingine.Editor;

namespace Wingine.Engine
{
    internal static class Program
    {
        static bool alive = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string proj = args.Length >= 1 ? args[0] : string.Empty;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            string homeAssetDir = "";

            if (File.Exists(proj) && proj.EndsWith(".wingine"))
            {
                string assets = Path.GetFullPath(Directory.GetParent(proj).FullName + "/assets");
                Directory.CreateDirectory(assets);
                homeAssetDir = assets;
            }
            
            var win = new Window(proj, homeAssetDir: homeAssetDir);
            win.FormClosing += (s, e) =>
            {
                alive = false;
            };

            System.Windows.Forms.Application.Run(win);
        }
    }
}
