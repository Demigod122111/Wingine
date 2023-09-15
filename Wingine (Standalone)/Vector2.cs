using System;

namespace Wingine
{
    [Serializable]
    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(double X, double Y)
        {
            this.X = (float)X;
            this.Y = (float)Y;
        }

        public static Vector2 Zero => new Vector2(0, 0);
        public static Vector2 One => new Vector2(1, 1);
        public static Vector2 Up => new Vector2(0, 1);
        public static Vector2 Down => new Vector2(0, -1);
        public static Vector2 Right => new Vector2(1, 0);
        public static Vector2 Left => new Vector2(-1, 0);

        public static Vector2 operator -(Vector2 a) => new Vector2(-a.X, -a.Y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.X - b.X, a.Y - b.Y);
        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator *(Vector2 a, double b) => new Vector2(a.X * b, a.Y * b);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.X * b.X, a.Y * b.Y);
        public static Vector2 operator /(Vector2 a, double b) => new Vector2(a.X / b, a.Y / b);


        public static implicit operator float(Vector2 vector) => vector.GetLength();


        public float Magnitude => GetLength();


        public float Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }

        public float GetLength()
        {
            return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        public override string ToString()
        {
            return $"X: {X} | Y: {Y}";
        }

        public static float DistanceSquared(Vector2 point1, Vector2 point2)
        {
            float distanceSquared =
                (point1.X - point2.X) * (point1.X - point2.X) +
                (point1.Y - point2.Y) * (point1.Y - point2.Y);
            return distanceSquared;
        }

        public static float Distance(Vector2 point1, Vector2 point2)
        {
            float distance = (float)Math.Sqrt
                (
                    (point1.X - point2.X) * (point1.X - point2.X) +
                    (point1.Y - point2.Y) * (point1.Y - point2.Y)
                );
            return distance;
        }

        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        {
            float deltaX = target.X - current.X;
            float deltaY = target.Y - current.Y;
            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance <= maxDistanceDelta || distance == 0f)
                return target;

            float factor = maxDistanceDelta / distance;
            float newX = current.X + deltaX * factor;
            float newY = current.Y + deltaY * factor;

            return new Vector2(newX, newY);
        }
    }
}
