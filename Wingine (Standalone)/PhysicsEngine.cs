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
                        if (/*!HasPair(body1, body2) &&*/ (body1.DetectCollisions && body2.DetectCollisions))
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

            var pds  = physicsBodies;
            foreach (var body in pds)
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

            b1bx.Width /= 1;
            b1bx.Height /= 1;

            b2bx.Width /= 1;
            b2bx.Height /= 1;


            if (b1bx.IntersectsWith(b2bx) && b2bx.IntersectsWith(b1bx))
            {
                return true;
            }
            return false;
        }


        // Calculate the normal force between two bodies in a collision.
        public static double CalculateNormalForce(double mass1, double velocity1_initial, double mass2, double velocity2_initial)
        {
            // Calculate relative velocity along the collision normal.
            double relativeVelocity = velocity1_initial - velocity2_initial;

            // Calculate the impulse.
            double impulse = mass1 * relativeVelocity;

            // Return the magnitude of the impulse as the normal force.
            return Math.Abs(impulse);
        }

        public static void ResolveCollision(PhysicsBody body1, PhysicsBody body2, float gravity)
        {
            float v2fx = 0f;
            float v2fy = 0f;

            float v1fx = 0f;
            float v1fy = 0f;

            if (body1.PhysicsType == body2.PhysicsType && body2.PhysicsType == PhysicsType.Static) return;

            // Elastic
            /// v2f=2⋅m1(m2+m1)v1i+(m2−m1)(m2+m1)v2i
            /*
            var v2x = (body2.Mass / body1.Mass) * body1.Mass * (body2.Mass + body1.Mass) * body1.Velocity.X + (body2.Mass - body1.Mass) * (body2.Mass + body1.Mass) * body2.Velocity.X;
            var v2y = (body2.Mass / body1.Mass) * body1.Mass * (body2.Mass + body1.Mass) * body1.Velocity.Y + (body2.Mass - body1.Mass) * (body2.Mass + body1.Mass) * body2.Velocity.Y;

            /// v1f=(m1−m2)(m2+m1)v1i+2⋅m2(m2+m1)v2i
            var v1x = (body1.Mass - body2.Mass) * (body2.Mass + body1.Mass) * body1.Velocity.X + (body2.Mass / body1.Mass) * body2.Mass * (body2.Mass + body1.Mass) * body2.Velocity.X;
            var v1y = (body1.Mass - body2.Mass) * (body2.Mass + body1.Mass) * body1.Velocity.Y + (body2.Mass / body1.Mass) * body2.Mass * (body2.Mass + body1.Mass) * body2.Velocity.Y;

            v1fx = v1x;
            v1fx = v1y;

            v2fx = v2x;
            v2fx = v2y;
            /*/

            // Inelastic
            // m1v1+m2v2 = (m1+m2)v′
            //*
            var ux = body1.Mass * body1.Velocity.X + body2.Mass * body2.Velocity.X;
            var uy = body1.Mass * body1.Velocity.Y + body2.Mass * body2.Velocity.Y;

            var vx = ux / (body1.Mass +  body2.Mass);
            var vy = uy / (body1.Mass +  body2.Mass);

            v1fx = v2fx = vx;
            v1fy = v2fy = vy;
            //*/

            RectangleF bounds1 = body1.BoundingBox;
            RectangleF bounds2 = body2.BoundingBox;


            if (body1.PhysicsType == PhysicsType.Dynamic)
            {
                body1.Velocity = new Vector2(v1fx, v1fy);

                // Calculate the centers of the two rectangles
                float center1X = bounds1.Left + bounds1.Width / 2;
                float center1Y = bounds1.Top + bounds1.Height / 2;
                float center2X = bounds2.Left + bounds2.Width / 2;
                float center2Y = bounds2.Top + bounds2.Height / 2;

                // Calculate the half-widths and half-heights of the two rectangles
                float halfWidth1 = bounds1.Width / 2;
                float halfHeight1 = bounds1.Height / 2;
                float halfWidth2 = bounds2.Width / 2;
                float halfHeight2 = bounds2.Height / 2;

                // Calculate the minimum overlap axis
                float overlapX = Math.Min(center1X + halfWidth1, center2X + halfWidth2) - Math.Max(center1X - halfWidth1, center2X - halfWidth2);
                float overlapY = Math.Min(center1Y + halfHeight1, center2Y + halfHeight2) - Math.Max(center1Y - halfHeight1, center2Y - halfHeight2);

                if (overlapX > 0 && overlapY > 0)
                {
                    // Resolve collision on the X-axis
                    if (overlapX < overlapY)
                    {
                        if (center1X < center2X)
                        {
                            // Move body1 to the left
                            body1.Transform.Position = new Vector2(body1.Transform.Position.X - overlapX, body1.Transform.Position.Y);
                        }
                        else
                        {
                            // Move body1 to the right
                            body1.Transform.Position = new Vector2(body1.Transform.Position.X + overlapX, body1.Transform.Position.Y);
                        }
                    }
                    // Resolve collision on the Y-axis
                    else
                    {
                        if (center1Y < center2Y)
                        {
                            // Move body1 upwards
                            body1.Transform.Position = new Vector2(body1.Transform.Position.X, body1.Transform.Position.Y - overlapY);
                        }
                        else
                        {
                            // Move body1 downwards
                            body1.Transform.Position = new Vector2(body1.Transform.Position.X, body1.Transform.Position.Y + overlapY);
                        }
                    }
                }
            }
            else if (body1.PhysicsType == PhysicsType.Static)
            {
                // Calculate the centers of the two rectangles
                float center1X = bounds1.Left + bounds1.Width / 2;
                float center1Y = bounds1.Top + bounds1.Height / 2 + body1.Offset.Y;
                float center2X = bounds2.Left + bounds2.Width / 2;
                float center2Y = bounds2.Top + bounds2.Height / 2 + body2.Offset.Y;

                // Calculate the half-widths and half-heights of the two rectangles
                float halfWidth1 = bounds1.Width / 2;
                float halfHeight1 = bounds1.Height / 2;
                float halfWidth2 = bounds2.Width / 2;
                float halfHeight2 = bounds2.Height / 2;

                // Calculate the minimum overlap axis
                float overlapX = Math.Min(center1X + halfWidth1, center2X + halfWidth2) - Math.Max(center1X - halfWidth1, center2X - halfWidth2);
                float overlapY = Math.Min(center1Y + halfHeight1, center2Y + halfHeight2) - Math.Max(center1Y - halfHeight1, center2Y - halfHeight2);

                if (overlapX > 0 && overlapY > 0)
                {
                    // Resolve collision on the X-axis
                    if (overlapX < overlapY)
                    {
                        if (center2X < center1X)
                        {
                            // Move body2 to the left
                            body2.Transform.Position = new Vector2(body2.Transform.Position.X - overlapX, body2.Transform.Position.Y);
                        }
                        else
                        {
                            // Move body2 to the right
                            body2.Transform.Position = new Vector2(body2.Transform.Position.X + overlapX, body2.Transform.Position.Y);
                        }
                    }
                    // Resolve collision on the Y-axis
                    else
                    {
                        if (center2Y < center1Y)
                        {
                            // Move body2 upwards
                            body2.Transform.Position = new Vector2(body2.Transform.Position.X, body2.Transform.Position.Y - overlapY);
                        }
                        else
                        {
                            // Move body2 downwards
                            body2.Transform.Position = new Vector2(body2.Transform.Position.X, body2.Transform.Position.Y + overlapY);
                        }
                    }
                }

                body2.Velocity = new Vector2(-v1fx, -v1fy);
            }

        }
    }
}
