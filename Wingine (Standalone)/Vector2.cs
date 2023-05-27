using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public float Dot(Vector2 other)
        {
            return X * other.X + Y * other.Y;
        }

        public override string ToString()
        {
            return $"X: {X} | Y: {Y}";
        }
    }
}
