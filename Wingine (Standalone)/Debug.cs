using System;
using System.Windows;
using System.Windows.Forms;

namespace Wingine
{
    public static class Debug
    {
        public static event DebugEvent DebugEventOccured;
        public delegate void DebugEvent(object msg, DebugType type);


        static DebugType lastType;
        public static object lastMsg { private set; get; }

        public static void NullLMSG() => lastMsg = null;

        public static event EventHandler CanRepeatChanged;
        public static bool CanRepeat
        {
            get
            {
                return canRepeat;
            }

            set
            {
                canRepeat = value;
                CanRepeatChanged?.Invoke(CanRepeat, null);
            }
        }

        static bool canRepeat = false;


        /// <summary>
        /// Re-outputs the last log to the console
        /// </summary>
        public static void Repeat()
        {
            Write(lastMsg, lastType);
        }

        /// <summary>
        /// Displays a popup with the given message.
        /// </summary>
        /// <param name="msg">The message</param>
        /// <param name="modal">The popup type</param>
        /// <returns></returns>
        public static void Popup(object msg, bool modal)
        {
            var tmsg = msg.ToString();

            if (modal) System.Windows.Forms.MessageBox.Show(tmsg);
            else System.Windows.MessageBox.Show(tmsg);
        }

        /// <summary>
        /// Checks to see if message and type is the same as the latest logged.
        /// </summary>
        /// <param name="msg">The query message</param>
        /// <param name="debugType">The query message type</param>
        /// <returns></returns>
        public static bool Repeated(object msg, DebugType debugType)
        {
            if (lastMsg == null && msg != null) return false;
            if (msg == null && lastMsg != null) return false;
            if (msg == null && lastMsg == null && lastType == debugType) return true;

            return lastType == debugType && (lastMsg.Equals(msg) || lastMsg == msg);
        }
        public static void Write(object msg) => Write(msg, DebugType.Log);
        public static void Write(object msg, DebugType debugType = DebugType.Log)
        {
            try
            {
                if (!CanRepeat && Repeated(msg, debugType)) return;

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
                    case DebugType.Editor:
                        c = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(msg);
                        Console.ForegroundColor = c;
                        break;
                    default:
                        Console.WriteLine(msg);
                        break;
                }

                if (DebugEventOccured != null) DebugEventOccured(msg, debugType);

                lastType = debugType;
                lastMsg = msg;
            }
            catch { }
        }

        public class DebugRef
        {
            public void Write(object msg, DebugType debugType = DebugType.Log)
            {
                Debug.Write(msg, debugType);
            }
        }

        public enum DebugType
        {
            Log,
            Warning,
            Error,
            Editor,
        }

    }
}
