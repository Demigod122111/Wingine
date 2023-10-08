using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine
{
    [Serializable]
    internal class PhysicsEngine
    {
        [NonSerialized]
        private List<PhysicsBody> physicsBodies = new List<PhysicsBody>();

        public float Gravity = 9.8f * 2f;

        public void AddPhysicsBody(PhysicsBody body)
        {
            physicsBodies.Add(body);
        }

        public bool ContainsPhysicsBody(PhysicsBody body)
        {
            return physicsBodies.Contains(body);
        }

        public void UpdatePhysics(double deltaTime)
        {
            // Broad-phase collision detection (simple example)
            List<Tuple<PhysicsBody, PhysicsBody>> potentialCollisions = new List<Tuple<PhysicsBody, PhysicsBody>>();
            for (int i = 0; i < physicsBodies.Count; i++)
            {
                for (int j = i + 1; j < physicsBodies.Count; j++)
                {
                    PhysicsBody body1 = physicsBodies[i];
                    PhysicsBody body2 = physicsBodies[j];

                    if (CollisionHandler.CheckCollision(body1, body2))
                    {
                        potentialCollisions.Add(new Tuple<PhysicsBody, PhysicsBody>(body1, body2));

                        var b1s = body1.GameObject.GetScripts();
                        for (int ii = 0; ii < b1s.Count; ii++)
                        {
                            if (b1s[ii].Enabled) b1s[ii].OnCollision(body2);
                        }

                        var b2s = body2.GameObject.GetScripts();
                        for (int ii = 0; ii < b2s.Count; ii++)
                        {
                            if (b2s[ii].Enabled) b2s[ii].OnCollision(body1);
                        }
                    }
                }
            }

            // Narrow-phase collision detection and resolution
            foreach (var collisionPair in potentialCollisions)
            {
                PhysicsBody body1 = collisionPair.Item1;
                PhysicsBody body2 = collisionPair.Item2;

                CollisionHandler.ResolveCollision(body1, body2);
            }

            foreach (var body in physicsBodies)
            {
                body.Update(deltaTime);
            }
        }
    }

    internal class CollisionHandler
    {
        public static bool CheckCollision(PhysicsBody body1, PhysicsBody body2)
        {
            // Check for collision between two rectangles using bounding boxes
            if (body1.BoundingBox.IntersectsWith(body2.BoundingBox))
            {
                return true;
            }
            return false;
        }

        public static void ResolveCollision(PhysicsBody body1, PhysicsBody body2)
        {
            // Calculate relative velocity
            PointF relativeVelocity = new PointF(
                body2.Velocity.X - body1.Velocity.X,
                body2.Velocity.Y - body1.Velocity.Y
            );

            // Calculate relative velocity in terms of the normal direction
            PointF normal = new PointF(
                body2.Transform.Position.X - body1.Transform.Position.X,
                body2.Transform.Position.Y - body1.Transform.Position.Y
            );

            float relativeSpeedAlongNormal = relativeVelocity.X * normal.X + relativeVelocity.Y * normal.Y;

            // Do not resolve if objects are moving apart
            if (relativeSpeedAlongNormal > 0)
            {
                return;
            }

            // Calculate the impulse (change in velocity) based on the coefficient of restitution
            float e = 0f; // Adjust as needed (1 is perfectly elastic, 0 is perfectly inelastic)
            float j = -(1 + e) * relativeSpeedAlongNormal / (
                1 / body1.Mass + 1 / body2.Mass
            );

            // Apply the impulse to both objects with consideration for their masses
            PointF impulse = new PointF(
                (j) * normal.X,
                (j) * normal.Y
            );

            body1.Velocity = new Vector2(
                body1.Velocity.X - (1 / body1.Mass) * impulse.X,
                body1.Velocity.Y - (1 / body1.Mass) * impulse.Y
            );

            body2.Velocity = new Vector2(
                body2.Velocity.X + (1 / body2.Mass) * impulse.X,
                body2.Velocity.Y + (1 / body2.Mass) * impulse.Y
            );
        }

    }
}
