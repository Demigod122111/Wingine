using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    public static class Debug
    {
        public static event DebugEvent DebugEventOccured;
        public delegate void DebugEvent(object msg, DebugType type);

        public static void Write(object msg, DebugType debugType = DebugType.Log)
        {
            try
            {
                switch (debugType)
                {
                    case DebugType.Log:
                        Console.WriteLine(msg);
                        break;
                    case DebugType.Warning:
                        ConsoleColor c = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(msg);
                        Console.ForegroundColor = c;
                        break;
                    case DebugType.Error:
                        Console.Error.WriteLine(msg);
                        break;
                    default:
                        Console.WriteLine(msg);
                        break;
                }

                if (DebugEventOccured != null) DebugEventOccured(msg, debugType);
            }
            catch { }
        }

        public enum DebugType
        {
            Log,
            Warning,
            Error,
        }
    }
}
