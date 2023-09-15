using System;

namespace Wingine
{
    [Serializable]
    public class Transform : IComponent
    {
        /// <summary>
        /// The local position of the GameObject.
        /// </summary>
        public Vector2 LocalPosition { get; set; }
        
        [HideInInspector]
        /// <summary>
        /// The position of the GameObject.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return GetPosition();
            }

            set
            {
                LocalPosition = ToLocalPosition(value);
            }
        }

        /// <summary>
        /// Returns the true position of the GameObject in respect of it's parent.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            if (this.GameObject.Parent != null)
            {
                return this.GameObject.Parent.Transform.GetPosition() + this.LocalPosition;
            }
            return this.LocalPosition;
        }

        Vector2 ToLocalPosition(Vector2 position)
        {
            if (this.GameObject.Parent != null)
            {
                return position - this.GameObject.Parent.Transform.GetPosition();
            }

            return position;
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


        [HideInInspector]
        public const int Rotation = 0;

#pragma warning disable CS0108 // 'Transform.GameObject' hides inherited member 'IComponent.GameObject'. Use the new keyword if hiding was intended.
        public readonly GameObject GameObject;
#pragma warning restore CS0108 // 'Transform.GameObject' hides inherited member 'IComponent.GameObject'. Use the new keyword if hiding was intended.

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
