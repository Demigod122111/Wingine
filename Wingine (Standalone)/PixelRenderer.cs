using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Wingine
{
    [Serializable]
    public class PixelRenderer : IComponent
    {
        internal RectangleF GraphicObject;

        public Vector2 HES => GetHighestExtreme(true);
        public Vector2 HE => GetHighestExtreme();

        public Vector2 LES => GetLowestExtreme(true);
        public Vector2 LE => GetLowestExtreme();

        [Multiline(160)]
        public string PixelData
        {
            get
            {
                return UPD;
            }

            set
            {
                UPD = value;
                Pixels = ExtractPixels(value);
            }
        }

        string UPD = "";

        public static List<Tuple<Vector2, Color, PixelType, FillType>> ExtractPixels(string pixelData)
        {
            List<Tuple<Vector2, Color, PixelType, FillType>> extractedPixels = new List<Tuple<Vector2, Color, PixelType, FillType>>();
            string[] tpls = pixelData.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\r\n", "").Split(';');
            foreach (var tpl in tpls)
            {
                if (tpl.Trim().StartsWith("#")) continue;

                string[] data = Regex.Split(tpl.Replace(" ", ""), ",");
                try
                {
                    extractedPixels.Add(new Tuple<Vector2, Color, PixelType, FillType>(
                        new Vector2(double.Parse(data[0]), double.Parse(data[1])),
                        Color.FromArgb(int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])),
                        (PixelType)Enum.GetValues(typeof(PixelType)).GetValue(int.Parse(data[6])),
                        (FillType)Enum.GetValues(typeof(FillType)).GetValue(int.Parse(data[7]))));
                }
                catch (Exception)
                {
                    if(Runner.UnderlyingDebug) Debug.Write($"Each pixel in the Pixel Data should follow the format:\n[horizontal position, vertical position, alpha, red, green, blue, pixel_type, fill_type]\nand ends with a ';'", Debug.DebugType.Warning);
                }
            }
            return extractedPixels;
        }

        [HideInInspector]
        public List<Tuple<Vector2, Color, PixelType, FillType>> Pixels { get; private set; } = new List<Tuple<Vector2, Color, PixelType, FillType>>();

        public Vector2 PixelSize = new Vector2(5, 5);

        public override void Begin()
        {

        }

        public override void Tick()
        {

        }

        public void SetPixels(List<Tuple<Vector2, Color, PixelType, FillType>> pixels)
        {
            Pixels = pixels;
        }

        public Vector2 GetHighestExtreme(bool includeSize = false)
        {
            double X = int.MinValue, Y = int.MinValue;

            foreach (var pixel in Pixels)
            {
                var xy = pixel.Item1;
                if (xy.X > X) X = xy.X;
                if (xy.Y > Y) Y = xy.Y;
            }

            return includeSize ? new Vector2(X + PixelSize.X / 2, Y + PixelSize.Y / 2) : new Vector2(X, Y);
        }

        public Vector2 GetLowestExtreme(bool includeSize = false)
        {
            double X = int.MaxValue, Y = int.MaxValue;

            foreach (var pixel in Pixels)
            {
                var xy = pixel.Item1;
                if (xy.X < X) X = xy.X;
                if (xy.Y < Y) Y = xy.Y;
            }

            return includeSize ? new Vector2(X + PixelSize.X / 2, Y + PixelSize.Y / 2) : new Vector2(X, Y);
        }

        public Vector2 GetMidpointExtreme(bool includeSize = false)
        {
            var min = GetLowestExtreme(includeSize: includeSize);
            var max = GetHighestExtreme(includeSize: includeSize);

            return new Vector2((min.X + max.X) / 2, (min.Y + max.Y) / 2);
        }
    }

    public enum PixelType
    {
        Rectangle,
        Circle,
    }

    public enum FillType
    {
        Fill,
        Empty,
    }
}
