using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wingine
{
    [Serializable]
    public class PhysicsBody : MonoBehaviour
    {
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public float Mass { get; set; } = 1;
        public Vector2 Radii { get; set; } = new Vector2(10, 10);

        public bool UseGravity = true;


        [Header("Debugging")]
        public bool showBoundingBox = false;

        public RectangleF BoundingBox => GetBoundingBox();

        RectangleF GetBoundingBox()
        {
            var pos = Transform.Position;
            var size = Radii;

            var x = pos.X - Radii.X / 2;
            var y = pos.Y - Radii.Y / 2;

            var width = Radii.X * 2;
            var height = Radii.Y * 2;

            return new RectangleF(x, y, width, height);
        }

        public override void Awake()
        {
            if (!Runner.App.PhysicsEngine.ContainsPhysicsBody(this))
            {
                Runner.App.PhysicsEngine.AddPhysicsBody(this);
            }
        }

        [NonSerialized]
        List<Vector2> forces = new List<Vector2>();

        public void AddForce(Vector2 force)
        {
            if(forces == null)
            {
                forces = new List<Vector2>();
            }
            forces.Add(force);
        }

        public void Update(double deltaTime)
        {
            AddForce(UseGravity ? new Vector2(0, -Runner.App.PhysicsEngine.Gravity) : Vector2.Zero);

            Acceleration = CalculateAcceleration(forces);


            // Update physics parameters based on acceleration, velocity, and time (deltaTime)
            Velocity = new Vector2(
                Velocity.X + Acceleration.X * deltaTime,
                Velocity.Y + Acceleration.Y * deltaTime
            );

            Transform.LocalPosition = new Vector2(
                Transform.LocalPosition.X + Velocity.X * deltaTime,
                Transform.LocalPosition.Y + Velocity.Y * deltaTime
            );

            forces.Clear();
        }

        Vector2 CalculateAcceleration(List<Vector2> forces)
        {
            // Calculate the net force by summing up all the individual forces
            double netForceX = 0;
            double netForceY = 0;

            for (int i = 0; i < forces.Count; i++)
            {
                netForceX += forces[i].X;
                netForceY += forces[i].Y;
            }

            // Calculate the acceleration using Newton's second law
            double accelerationX = netForceX / Mass;
            double accelerationY = netForceY / Mass;

            return new Vector2(accelerationX, accelerationY);
        }
    }
}
