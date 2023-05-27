using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    [Serializable]
    public abstract class MonoBehaviour : IComponent
    {
        public bool Awaked { get; internal set; }

        public virtual void Awake() { }

        public override void Begin()
        {
            
        }

        public override void Tick()
        {

        }

        public virtual void Start() { }
        public virtual void Update() { }
    }
}
