using System;

namespace Wingine
{
    [Serializable]
    public abstract class MonoBehaviour : IComponent
    {
        public MonoBehaviour()
        {

        }

        public bool Awaked { get; internal set; }


        public override void Begin() { }
        public override void Tick() { }


        public virtual void Awake() { }
        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }
}
