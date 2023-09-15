using System;
using System.Drawing;

namespace Wingine
{
    [Serializable]
    public class Camera : IComponent
    {
        public static Camera Main => GameObject.FindByTag("MainCamera")?.GetComponentOfType<Camera>();

        public Color BackgroundColor = Color.White;

        [HideInInspector]
        public int fieldOfView = 2000;

        public Tuple<Vector2, Vector2> GetBounds() => new Tuple<Vector2, Vector2>(
            new Vector2(Transform.Position.X - fieldOfView / 2, Transform.Position.Y + fieldOfView / 2),
            new Vector2(Transform.Position.X + fieldOfView / 2, Transform.Position.Y - fieldOfView / 2));

        public bool WithinBounds(Vector2 point)
        {
            var bounds = GetBounds();
            var upperBounds = bounds.Item1;
            var lowerBounds = bounds.Item2;

            if (point.X >= upperBounds.X && point.Y <= upperBounds.Y &&
               point.X <= lowerBounds.X && point.Y >= lowerBounds.Y)
            {
                return true;
            }

            return false;
        }

        public override void Begin()
        {

        }

        public override void Tick()
        {

        }
    }
}
