using System;
using System.Collections.Generic;

namespace Wingine
{
    [Serializable]
    public class PhysicsBody : IComponent
    {
        internal delegate void PhysicsEvent();
        internal static event PhysicsEvent PhysicsUpdate;
        internal static void InternalPhysicsUpdate()
        {
            //PhysicsUpdate?.Invoke();
        }

        public static float BaseGravity = 39.2f;

        public float Gravity = 1f;
        public float Mass = 1f;
        public Vector2 Velocity = Vector2.Zero;

        List<Vector2> forces = new List<Vector2>();

        public PhysicsBody()
        {
            Init();
        }

        public override void Begin()
        {
            Init();
        }

        Vector2 refForce = Vector2.Zero;
        public Vector2 CapturedForce => refForce;

        private void PhysicsBody_PhysicsUpdate()
        {
            var timeStep = Time.FixedDeltaTime;

            if (GameObject != null)
            {
                Transform.Position = Transform.Position + Velocity * timeStep;
            }

            Vector2 force = new Vector2(0, -(Gravity * PhysicsBody.BaseGravity));

            lock (forces)
            {
                forces.ForEach((f) => { force += f; });

                var vx = Velocity.X + (force.X / Mass) * timeStep;
                var vy = Velocity.Y + (force.Y / Mass) * timeStep;

                Velocity = new Vector2(vx, vy);

                forces.Clear();
            }

            refForce = force;
        }

        public void AddForce(Vector2 force)
        {
            forces.Add(force);
        }

        public Vector2 GetForce() => refForce;

        public override void Tick()
        {

        }

        internal void Init()
        {
            PhysicsUpdate += PhysicsBody_PhysicsUpdate;
        }
    }
}
