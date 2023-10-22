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
        public PhysicsType PhysicsType = PhysicsType.Dynamic;
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        [Range(min: 0.01, max: 2147483647)]
        public float Mass { get; set; } = 1;

        [Header("Collider")]
        public Vector2 Radii { get; set; } = new Vector2(10, 10);
        public Vector2 Offset { get; set; } = Vector2.Zero;
        public bool DetectCollisions = true;


        [Header("Gravity")]
        public bool UseGravity = true;
        public float GravityCoefficient = 1f;


        [Header("Debugging")]
        public bool showBoundingBox = false;

        public RectangleF BoundingBox => GetBoundingBox();

        RectangleF GetBoundingBox()
        {
            var pos = Transform.Position;
            var size = Radii;

            var x = pos.X - Radii.X / 2 + Offset.X;
            var y = pos.Y - Radii.Y / 2 + Offset.Y;

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
            AddForce((UseGravity && PhysicsType == PhysicsType.Dynamic) ? new Vector2(0, -Runner.App.PhysicsEngine.Gravity * GravityCoefficient) : Vector2.Zero);

            if (PhysicsType == PhysicsType.Dynamic)
            {
                Acceleration = CalculateAcceleration(forces);


                // Update physics parameters based on acceleration, velocity, and time (deltaTime)
                Velocity = new Vector2(
                    Velocity.X + Acceleration.X * deltaTime,
                    Velocity.Y + Acceleration.Y * deltaTime
                );

                
                Transform.Position += new Vector2(Velocity.X * deltaTime, Velocity.Y * deltaTime);
            }

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

    public enum PhysicsType { Static, Dynamic }
}
