using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    [Serializable]
    public abstract class IComponent
    {
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
