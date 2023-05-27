using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    [Serializable]
    public class GameObject
    {
        public static event EventHandler ParentChanged;

        public string Name = "New GameObject";

        public string Tag = "";

        [HideInInspector]
        public GameObject Parent { get; private set; }
        public void SetParent(GameObject parent)
        {
            Parent = parent;
            ParentChanged(this, new EventArgs());
        }

        public static event EventHandler ActiveChanged;
        public bool ActiveSelf { get; private set; } = true;

        public void SetActive(bool value)
        {
            ActiveSelf = value;
            ActiveChanged(this, new EventArgs());
        }

        public bool ActiveInHierarchy()
        {
            if(Parent != null)
            {
                return (Parent.ActiveInHierarchy() && ActiveSelf);
            }
            return ActiveSelf;
        }

        public readonly Transform Transform;

        readonly List<IComponent> Components = new List<IComponent>();
        public List<IComponent> GetComponents() => Components;

        readonly List<MonoBehaviour> Scripts = new List<MonoBehaviour>();
        public List<MonoBehaviour> GetScripts() => Scripts;

        string InspectorID;
        public void SetInspectorID(string id) => InspectorID = id;
        public string GetInspectorID() => InspectorID;

        public GameObject(string name = "New GameObject")
        {
            Transform = new Transform(this);
            Components.Add(Transform);
            Name = name;

            if (Runner.App.CurrentScene != null)
            {
                Runner.App.CurrentScene.AddGameObject(this);
            }
        }

        public IComponent AddComponent(Type type)
        {
            if (type == typeof(Transform)) throw new Exception("Cannot add component of type 'Transform'.");

            var comp = Activator.CreateInstance(type);

            if (comp is IComponent || comp is MonoBehaviour)
            {
                Components.Add(comp as IComponent);

                if (comp is MonoBehaviour)
                {
                    Scripts.Add(comp as MonoBehaviour);
                }

                (comp as IComponent).GameObject = this;
                return (IComponent) comp;
            }
            else
            {
                return default(IComponent);
            }
        }

        public T AddComponent<T>(bool search_up_stream = false)
        {
            if (typeof(T) == typeof(Transform)) throw new Exception("Cannot add component of type 'Transform'.");

            T comp = Activator.CreateInstance<T>();

            if(comp is IComponent || comp is MonoBehaviour)
            {
                Components.Add(comp as IComponent);

                if(comp is MonoBehaviour)
                {
                    Scripts.Add(comp as MonoBehaviour);
                }

                (comp as IComponent).GameObject = this;
                return comp;
            }
            else
            {
                return default(T);
            }

        }
        public T GetComponent<T>(bool search_up_stream = false)
        {
            foreach (var component in Components)
            {
                if (component.GetType() == typeof(T)) return (T)((object)component);
            }

            if (search_up_stream && Parent != null) return Parent.GetComponent<T>();

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
                if((object) component == (object)Transform)
                {
                    Debug.Write("Cannot remove `Transform` component.", Debug.DebugType.Error);
                    return;
                }

                Components.Remove(component);
            }
            catch(Exception e)
            {
                Debug.Write(e.Message, Debug.DebugType.Error);
            }
        }

        public void Destroy()
        {
            Runner.App.CurrentScene.RemoveGameObject(this);
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
    }
}
