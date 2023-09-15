using System;

namespace Wingine
{
    [Serializable]
    public abstract class IComponent
    {
        [NonSerialized]
        internal bool Began = false;

        [HideInInspector]
        public GameObject GameObject { get; set; }
        [HideInInspector]
        public virtual Transform Transform => GameObject.Transform;

        [HideInInspector]
        public bool Enabled = true;

        public abstract void Begin();
        public abstract void Tick();
    }
}
