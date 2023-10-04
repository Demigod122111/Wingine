using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Wingine
{
    [Serializable]
    public class GameObject
    {
        public string ID { get; private set; }

        public static event EventHandler NameChanged;


        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name)) name = "New GameObject";
                return name;
            }
            set
            {
                name = value;

                NameChanged?.Invoke(this, null);
            }
        }

        string name;

        public string Tag = "";

        public static event EventHandler ParentChanged;

        [HideInInspector]
        public GameObject Parent { get; private set; }

        public void SetParent(GameObject parent)
        {
            Parent?.Children.Remove(this);

            Parent = parent;

            Parent?.Children.Add(this);

            ParentChanged(this, new EventArgs());
        }

        List<GameObject> Children = new List<GameObject>();

        public static event EventHandler ActiveChanged;
        public bool ActiveSelf { get; private set; } = true;

        public void SetActive(bool value)
        {
            ActiveSelf = value;
            ActiveChanged(this, new EventArgs());
        }

        public bool ActiveInHierarchy()
        {
            if (Parent != null)
            {
                return (Parent.ActiveInHierarchy() && ActiveSelf);
            }
            return ActiveSelf;
        }

        public readonly Transform Transform;

        readonly List<IComponent> Components = new List<IComponent>();
        public List<IComponent> GetComponents() => Components;
        public List<IComponent> GetComponentsOfType<T>() => Components.FindAll((ic) => ic.GetType() == typeof(T));
        public List<IComponent> GetComponentsOfType(Type T) => Components.FindAll((ic) => ic.GetType() == T);

        readonly List<MonoBehaviour> Scripts = new List<MonoBehaviour>();
        public List<MonoBehaviour> GetScripts() => Scripts;

        readonly List<Script> JSScripts = new List<Script>();
        public List<Script> GetJSScripts() => JSScripts;

        string InspectorID;
        public void SetInspectorID(string id) => InspectorID = id;
        public string GetInspectorID() => InspectorID;

        public GameObject(string name = "New GameObject")
        {
            Transform = new Transform(this);
            Components.Add(Transform);
            this.name = name;

            if (Runner.App.CurrentScene != null)
            {
                Runner.App.CurrentScene.AddGameObject(this);
            }

            CheckID();
        }

        public bool Exists()
        {
            return Runner.App?.CurrentScene?.GameObjects.Contains(this) ?? false;
        }

        internal void CheckID()
        {
            if (string.IsNullOrEmpty(ID)) ID = DateTime.UtcNow.Ticks.ToString();
        }

        public IComponent AddComponent(Type type)
        {
            if (type == typeof(Transform)) throw new Exception("Cannot add component of type 'Transform'.");

            var comp = Activator.CreateInstance(type);

            if (comp is IComponent || comp is MonoBehaviour)
            {
                Components.Add(comp as IComponent);

                if (comp is Script)
                {
                    JSScripts.Add(comp as Script);
                }
                else if (comp is MonoBehaviour)
                {
                    Scripts.Add(comp as MonoBehaviour);
                }

                (comp as IComponent).GameObject = this;
                return (IComponent)comp;
            }
            else
            {
                return default;
            }
        }

        public T AddComponent<T>()
        {
            if (typeof(T) == typeof(Transform)) throw new Exception("Cannot add component of type 'Transform'.");

            T comp = Activator.CreateInstance<T>();

            if (comp is IComponent || comp is MonoBehaviour)
            {
                Components.Add(comp as IComponent);

                if (comp is Script)
                {
                    JSScripts.Add(comp as Script);
                }
                else if (comp is MonoBehaviour)
                {
                    Scripts.Add(comp as MonoBehaviour);
                }

                (comp as IComponent).GameObject = this;
                return comp;
            }
            else
            {
                return default;
            }

        }

        public object GetComponentOfType(Type type, bool search_up_stream = false)
        {
            foreach (var component in Components)
            {
                if (component.GetType() == type) return component;
            }

            if (search_up_stream && Parent != null) return Parent.GetComponentOfType(type, true);

            return null;
        }

        public object GetComponentOfType(Type type)
        {
            foreach (var component in Components)
            {
                if (component.GetType() == type) return component;
            }


            return null;
        }

        public T GetComponentOfType<T>(bool search_up_stream = false)
        {
            foreach (var component in Components)
            {
                if (component.GetType() == typeof(T)) return (T)((object)component);
            }

            if (search_up_stream && Parent != null) return Parent.GetComponentOfType<T>(true);

            return default(T);
        }

        public bool ComponentExists<T>()
        {
            foreach (var component in Components)
            {
                if (component.GetType() == typeof(T)) return true;
            }

            return false;
        }

        public void RemoveComponent(IComponent component)
        {
            try
            {
                if (component == Transform)
                {
                    Debug.Write("Cannot remove `Transform` component.", Debug.DebugType.Error);
                    return;
                }

                if (component is Script)
                {
                    JSScripts.Remove(component as Script);
                }
                else if (component is MonoBehaviour)
                {
                    Scripts.Remove(component as MonoBehaviour);
                }

                Components.Remove(component);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message, Debug.DebugType.Error);
            }
        }

        public void Destroy()
        {
            Runner.App.CurrentScene.RemoveGameObject(this);

            for (int i = 0; i < Children.Count; i++)
            {
                Children[i].Destroy();
            }
        }

        public static GameObject FindByTag(string tag)
        {
            if (Runner.App.CurrentScene == null)
            {
                Debug.Write("Current Scene is null", Debug.DebugType.Error);
                return null;
            }

            foreach (var go in Runner.App.CurrentScene.GameObjects)
            {
                if (go.Tag == tag) return go;
            }

            return null;
        }

        public GameObject Duplicate()
        {
            DataStore.WriteToBinaryFile<GameObject>("./DGTEMP.cache", this);
            var dupe = DataStore.ReadFromBinaryFile<GameObject>("./DGTEMP.cache");
            File.Delete("./DGTEMP.cache");
            dupe.Parent = Parent;
            if (!Runner.App.CurrentScene.GameObjects.Contains(dupe)) Runner.App.CurrentScene.AddGameObject(dupe);
            dupe.Name = $"{Name} (Copy)";
            return dupe;
        }

        public void Tick()
        {
            for (int i = 0; i < Components.Count; i++)
            {
                if (!Components[i].Enabled) continue;
                Components[i].Tick();
            }
        }
    }

    [Serializable]
    public class IGameObjectComparer : IComparer<GameObject>
    {
        public int Compare(GameObject x, GameObject y)
        {
            var i1 = Runner.App.CurrentScene.GameObjects.IndexOf(x);
            var i2 = Runner.App.CurrentScene.GameObjects.IndexOf(y);

            if (i1 == 0 || i2 == 0)
            {
                return 0;
            }

            return i1.CompareTo(i2);
        }
    }
}
