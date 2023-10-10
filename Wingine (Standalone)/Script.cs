using System;
using System.Linq;
using Wingine.Scripting;

namespace Wingine
{
    [Serializable]
    public class Script : MonoBehaviour
    {
        internal ScriptEngine Core = new ScriptEngine();

        [Multiline(360)]
        public string Code;

        public Script()
        {
            Code =
@"
// Called once at the start of the game
function start(){

}

// Called once every frame
function update(){

}
";
        }

        [NonSerialized]
        bool doneInit = false;
        void InitEngine()
        {
            doneInit = false;

            Core.engine = new Jint.Engine();
            Core.engine.SetValue("gameObject", GameObject);
            Core.engine.SetValue("transform", Transform);
            Core.engine.SetValue("actor", this);

            var targetNamespaces = new string[] {
                "Wingine",
                "Wingine.SceneManagement",
                "Wingine.UI",

                "System",
                "System.Drawing",
                "System.Collections.Generic",
                "System.Windows.Forms",
            };

            Core.engine = Core.engine.SetValue("Key", typeof(System.Windows.Input.Key));
            Core.engine = Core.engine.SetValue("Application", Runner.App);

            for (int i = 0; i < targetNamespaces.Length; i++)
            {
                var targetNamespace = targetNamespaces[i];

                var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => a.GetTypes().Any(t => t.Namespace == targetNamespace));

                foreach (var assembly in assemblies)
                {
                    var types = assembly.GetTypes().Where(t => t.Namespace == targetNamespace && (t.IsClass || t.IsEnum || t.IsArray || t.IsValueType));

                    foreach (var type in types)
                    {
                        if (type == typeof(Runner)) continue;
                        if (type == typeof(Application)) continue;


                        var val = Core.engine.GetValue(type.Name);

                        if (val.Type == Jint.Runtime.Types.Undefined ||
                            val.Type == Jint.Runtime.Types.None ||
                            val.Type == Jint.Runtime.Types.Null ||
                            val.ToObject() == null)
                        {
                            Core.engine = Core.engine.SetValue(type.Name, type);
                        }
                        else
                        {
                            Core.engine = Core.engine.SetValue(type.FullName, type);
                        }
                    }
                }
            }

            try
            {
                Core.engine = Core.Execute(Code);
            }
            catch (Exception e)
            {
                Debug.Write($"{e.Message}\nfrom: Script\non: {GameObject.Name}", Debug.DebugType.Error);

                if (e.InnerException != null)
                {
                    Debug.Write($"\n\nRoot Cause:\n{e.InnerException.Message}", Debug.DebugType.Error);
                }
            }

            doneInit = true;
        }

        public override void Begin()
        {
            base.Begin();
        }

        void InvokeFunction(string name, bool forceInit = false, params object[] args)
        {
            if (forceInit) InitEngine();
            else
            {
                if (Core.engine == null) InitEngine();
            }

            if (!doneInit) return;

            try
            {
                var val = Core.engine.GetValue(name);
                var v = val.IsObject() && val.AsObject().Class == "Function";
                if (v) Core.engine.Invoke(name, args);
            }
            catch (Exception e)
            {
                Debug.Write($"{e.Message}\nat {name}()\nfrom: Script\non: {GameObject.Name}", Debug.DebugType.Error);

                if (e.InnerException != null)
                {
                    Debug.Write($"\n\nRoot Cause:\n{e.InnerException.Message}", Debug.DebugType.Error);
                }
            }
        }

        public override void Awake()
        {
            InvokeFunction("awake", forceInit: true);
        }

        public override void Start()
        {
            InvokeFunction("start", forceInit: true);
        }

        public override void Update()
        {
            InvokeFunction("update");
        }

        public override void FixedUpdate()
        {
            InvokeFunction("fixedUpdate");
        }

        public override void OnCollision(PhysicsBody other)
        {
            InvokeFunction("onCollision", false, other);
        }
    }
}
