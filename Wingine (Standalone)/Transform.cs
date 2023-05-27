using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    [Serializable]
    public class Transform : IComponent
    {
        /// <summary>
        /// The local position of the GameObject.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Returns the true position of the GameObject in respect of it's parent.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            if (this.GameObject.Parent != null)
            {
                return this.GameObject.Parent.Transform.GetPosition() + this.Position;
            }
            return this.Position;
        }

        /// <summary>
        /// The local scale of the GameObject.
        /// </summary>
        public Vector2 Scale { get; set; } = Vector2.One;

        /// <summary>
        /// Returns the true scale of the GameObject in respect of it's parent.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetScale()
        {
            if (this.GameObject.Parent != null)
            {
                return this.GameObject.Parent.Transform.GetScale() + this.Scale;
            }
            return this.Scale;
        }


        public int Rotation = 0;

        public readonly GameObject GameObject;

        public Transform(GameObject go)
        {
            GameObject = go;
        }

        public override void Begin()
        {
            
        }

        public override void Tick()
        {
            
        }
    }
}
