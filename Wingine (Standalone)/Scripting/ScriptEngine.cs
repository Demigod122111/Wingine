using Jint;
using System;

namespace Wingine.Scripting
{
    [Serializable]
    public class ScriptEngine
    {
        [NonSerialized]
        public Engine engine;

        public Engine Execute(string code)
        {
            return engine.Execute(code);
        }
    }
}
