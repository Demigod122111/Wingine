using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wingine.Helpers;

namespace Wingine
{
    [Serializable]
    public class Collider : IComponent
    {
        static List<Collider> Colliders = new List<Collider>();

        public Vector2 Size;
        public Vector2 Offset = Vector2.Zero;
        public PhysicsBody PhysicsBody;
        public bool ShowBounds = false;
        public bool ShowPhysicsData = false;

        public float frc = 0f;

        bool InitSize = false;

        public override void Begin()
        {
            DoEval();
            if (!InitSize)
            {
                Size = GetRadius();
                InitSize = true;
            }
        }

        public override void Tick()
        {
            Colliders.AddIfNotPresent(this);
            EvalCollision();
        }

        async void DoEval()
        {
            new Thread(new ThreadStart(async () =>
            {
                while (true)
                {
                    await Task.Delay((int)(1000 * Time.FixedDeltaTime));

                    EvalCollision();
                }
            })).Start();
        }

        List<Collider> collisions = new List<Collider>();

        Vector2 GetRadius()
        {
            List<Vector2> points = GetPointsInObject(Transform);

            // Estimate the radius using the bounding circle approach
            float boundingRadius = GetBoundingCircleRadius(points);

            var radius = new Vector2(boundingRadius, boundingRadius);

            if (GameObject.ComponentExists<PixelRenderer>())
            {
                var pr = GameObject.GetComponentOfType<PixelRenderer>();
                var ex1 = pr.GetHighestExtreme(includeSize: true);
                var ex2 = pr.GetLowestExtreme(includeSize: true);
                var ex = new Vector2(ex1.X - ex2.X, ex1.Y - ex2.Y);
                radius += new Vector2(ex.X, ex.Y);
            }

            return radius;
        }
        void EvalCollision()
        {
            foreach (var collider in Colliders)
            {
                if (collider == this) continue;

                Transform t = collider.Transform;

                // USE: Bounding Circle
                var collided = CheckCollision(Transform.Position, Size, t.Position, collider.Size);

                if (collided)
                {
                    collisions.AddIfNotPresent(collider);
                    var tpb = t.GameObject.GetComponentOfType<PhysicsBody>();
                    var pb = GameObject.GetComponentOfType<PhysicsBody>();
                    PhysicsBody = pb;
                    //frc = PhysicsBody.CapturedForce;

                    var bConstant = (tpb.Mass / (pb.Mass + tpb.Mass));
                    //var hforce = pb.GetForce() / 2 * bConstant;

                    //tpb.AddForce(hforce * 4);
                    //pb.AddForce(-hforce * 2);
                }
                else
                {
                    collisions.Remove(collider);
                }
            }
        }


        public static bool CheckCollision(Vector2 position1, Vector2 radius1, Vector2 position2, Vector2 radius2)
        {
            // Calculate the squared distance between the centers of the two objects
            float distanceSquared = Vector2.DistanceSquared(position1, position2);

            // Calculate the sum of the squared radii
            float radiiSumSquared = (float)Math.Pow(radius1.GetLength() * 1f + radius2.GetLength() * 1f, 2);

            // Check if the squared distance is less than or equal to the squared radii sum
            return distanceSquared <= radiiSumSquared;
        }

        static float GetBoundingCircleRadius(List<Vector2> points)
        {
            // Calculate the centroid (center of mass) of the points
            Vector2 centroid = new Vector2(
                points.Sum(p => p.X) / points.Count,
                points.Sum(p => p.Y) / points.Count
            );

            // Find the maximum distance between the centroid and any point on the object
            float maxDistance = points.Max(p => Vector2.Distance(centroid, p));

            return maxDistance;
        }

        static List<Vector2> GetPointsInObject(Transform t)
        {
            List<Vector2> points = new List<Vector2>
                {
                    new Vector2(t.Position.X - (t.Scale.X / 2), t.Position.Y + (t.Scale.Y / 2)),
                    new Vector2(t.Position.X + (t.Scale.X / 2), t.Position.Y + (t.Scale.Y / 2)),
                    new Vector2(t.Position.X - (t.Scale.X / 2), t.Position.Y - (t.Scale.Y / 2)),
                    new Vector2(t.Position.X + (t.Scale.X / 2), t.Position.Y - (t.Scale.Y / 2))
                };
            return points;
        }
    }
}
