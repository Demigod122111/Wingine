using System;

namespace Wingine.Editor
{
    public static class EditorLink
    {
        public delegate void ComponentMenuEvent(Type type);
        public static event ComponentMenuEvent AddComponentEvent;

        public static void AddComponentToMenu(Type t)
        {
            if (AddComponentEvent != null) AddComponentEvent(t);
        }
    }
}
