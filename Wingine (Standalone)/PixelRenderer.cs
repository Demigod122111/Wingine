using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Wingine
{
    [Serializable]
    public class PixelRenderer : IComponent
    {

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
                List<Tuple<Vector2, Color, PixelType, FillType>> extractedPixels = new List<Tuple<Vector2, Color, PixelType, FillType>>();

                string[] tpls = UPD.Trim().Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\r\n", "").Split(';');
                foreach (var tpl in tpls)
                {
                    string[] data = Regex.Split(tpl, ",");
                    try
                    {
                        extractedPixels.Add(new Tuple<Vector2, Color, PixelType, FillType>(
                            new Vector2(double.Parse(data[0]), double.Parse(data[1])),
                            Color.FromArgb(int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4])),
                            (PixelType)Enum.GetValues(typeof(PixelType)).GetValue(int.Parse(data[5])),
                            (FillType)Enum.GetValues(typeof(FillType)).GetValue(int.Parse(data[6]))));
                    }
                    catch (Exception e)
                    {
                        
                    }
                }

                Pixels = extractedPixels;
            }
        }

        string UPD = "";

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

        public Vector2 GetExtreme()
        {
            double X = 0, Y = 0;

            foreach (var pixel in Pixels)
            {
                var xy = pixel.Item1;
                if (xy.X > X) X = xy.X;
                if (xy.Y > Y) Y = xy.Y;
            }

            return new Vector2(X, Y);
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
