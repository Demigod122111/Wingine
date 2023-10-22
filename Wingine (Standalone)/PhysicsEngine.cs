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

            bool HasPair(PhysicsBody pb1, PhysicsBody pb2)
            {
                for (int i = 0; i < potentialCollisions.Count; i++)
                {
                    var pair = potentialCollisions[i];

                    if((pair.Item1 == pb1 && pair.Item2 == pb2) || (pair.Item1 == pb2 && pair.Item2 == pb1))
                    {
                        return true;
                    }
                }

                return false;
            }

            for (int i = 0; i < physicsBodies.Count; i++)
            {
                for (int j = i + 1; j < physicsBodies.Count; j++)
                {
                    PhysicsBody body1 = physicsBodies[i];
                    PhysicsBody body2 = physicsBodies[j];

                    if (CollisionHandler.CheckCollision(body1, body2))
                    {
                        if (!HasPair(body1, body2) && (body1.DetectCollisions && body2.DetectCollisions))
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
            }

            // Narrow-phase collision detection and resolution
            foreach (var collisionPair in potentialCollisions)
            {
                PhysicsBody body1 = collisionPair.Item1;
                PhysicsBody body2 = collisionPair.Item2;

                CollisionHandler.ResolveCollision(body1, body2, Gravity);
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
            var b1bx = body1.BoundingBox;
            var b2bx = body2.BoundingBox;

            b1bx.Width /= 2;
            b1bx.Height /= 2;

            b2bx.Width /= 2;
            b2bx.Height /= 2;

            if (b1bx.IntersectsWith(b2bx))
            {
                return true;
            }
            return false;
        }

        public static void ResolveCollision(PhysicsBody body1, PhysicsBody body2, float gravity)
        {
            float v2fx = 0f;
            float v2fy = 0f;

            float v1fx = 0f;
            float v1fy = 0f;

            /// Body 2 Final Velocity
            /// v2f=2⋅m1(m2+m1)v1i+(m2−m1)(m2+m1)v2i
            v2fx = (body2.Mass / body1.Mass) * body1.Mass * (body2.Mass + body1.Mass) * body1.Velocity.X + (body2.Mass - body1.Mass) * (body2.Mass + body1.Mass) * body2.Velocity.X;
            v2fy = (body2.Mass / body1.Mass) * body1.Mass * (body2.Mass + body1.Mass) * body1.Velocity.Y + (body2.Mass - body1.Mass) * (body2.Mass + body1.Mass) * body2.Velocity.Y;

            /// Body 1 Final Velocity
            /// v1f=(m1−m2)(m2+m1)v1i+2⋅m2(m2+m1)v2i
            v1fx = (body1.Mass - body2.Mass) * (body2.Mass + body1.Mass) * body1.Velocity.X + (body2.Mass / body1.Mass) * body2.Mass * (body2.Mass + body1.Mass) * body2.Velocity.X;
            v1fy = (body1.Mass - body2.Mass) * (body2.Mass + body1.Mass) * body1.Velocity.Y + (body2.Mass / body1.Mass) * body2.Mass * (body2.Mass + body1.Mass) * body2.Velocity.Y;

            

            if (body1.PhysicsType == PhysicsType.Dynamic)
            {
                var gravityUp = body1.UseGravity ? (gravity * body1.GravityCoefficient) * Math.Sqrt(Time.DeltaTime) : 0;
                body1.Velocity = new Vector2(v1fx, v1fy + gravityUp);
            }

            if (body2.PhysicsType == PhysicsType.Dynamic)
            {
                var gravityUp = body2.UseGravity ? (gravity * body2.GravityCoefficient) * Math.Sqrt(Time.DeltaTime) : 0;
                body2.Velocity = new Vector2(v2fx, v2fy + gravityUp);
            }
        }
    }
}
