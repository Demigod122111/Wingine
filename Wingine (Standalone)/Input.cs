using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wingine
{
    public static class Input
    {
        public static bool GetKeyDown(Key key)
        {
             return Keyboard.IsKeyDown(key);
        }

        public static bool GetKeyUp(Key key)
        {           
            return Keyboard.IsKeyUp(key);
        }

        public static bool GetKeyToggled(Key key)
        {
            return Keyboard.IsKeyToggled(key);
        }
    }
}
