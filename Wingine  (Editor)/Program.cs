using System;
using Wingine.Editor;

namespace Wingine.Engine
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string proj = args.Length >= 1 ? args[0] : string.Empty;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Window(proj));
        }
    }
}
