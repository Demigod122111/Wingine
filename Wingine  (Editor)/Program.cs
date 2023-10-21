using System;
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

            new Thread(new ThreadStart(() =>
            {
                while (alive)
                {
                    System.Windows.Forms.Application.DoEvents();
                }
            }));

            var win = new Window(proj);
            win.FormClosing += (s, e) =>
            {
                alive = false;
            };

            System.Windows.Forms.Application.Run(win);
        }
    }
}
