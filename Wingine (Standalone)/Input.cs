﻿using System;
using System.Windows.Input;

namespace Wingine
{
    public static class Input
    {
        internal static bool LeftMouse = false;
        internal static bool RightMouse = false;

        public static Vector2 MousePosition = Vector2.Zero;


        internal static void Init()
        {

        }

        public enum MouseButton { Left, Right }

        public static bool GetMouseClick(MouseButton button)
        {
            if ((Runner.App?.IsRunning ?? false) && (!Runner.App?.Focused ?? false)) return false;

            throw new NotImplementedException();
        }

        public static bool IsMouseButtonDown(MouseButton button)
        {
            if ((Runner.App?.IsRunning ?? false) && (!Runner.App?.Focused ?? false)) return false;

            switch (button)
            {
                case MouseButton.Left:
                    return LeftMouse == true;

                case MouseButton.Right:
                    return RightMouse == true;

                default:
                    return false;

            }
        }

        public static bool IsMouseButtonUp(MouseButton button)
        {
            if ((Runner.App?.IsRunning ?? false) && (!Runner.App?.Focused ?? false)) return false;

            switch (button)
            {
                case MouseButton.Left:
                    return LeftMouse == false;

                case MouseButton.Right:
                    return RightMouse == false;

                default:
                    return false;

            }
        }

        public static bool GetKeyDown(Key key)
        {
            if ((Runner.App?.IsRunning ?? false) && (!Runner.App?.Focused ?? false)) return false;
            return Keyboard.IsKeyDown(key);
        }

        public static bool GetKeyUp(Key key)
        {
            if ((Runner.App?.IsRunning ?? false) && (!Runner.App?.Focused ?? false)) return false;
            return Keyboard.IsKeyUp(key);
        }

        public static bool GetKeyToggled(Key key)
        {
            if ((Runner.App?.IsRunning ?? false) && (!Runner.App?.Focused ?? false)) return false;
            return Keyboard.IsKeyToggled(key);
        }
    }
}
