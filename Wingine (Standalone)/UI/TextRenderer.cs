using System;
using System.Drawing;
using System.Collections.Generic;

namespace Wingine.UI
{
    [Serializable]
    public class TextRenderer : IUIComponent
    {
        public string Text = "";

        [Header("Font Settings")]
        [ExtendColor]
        public Color Color = Color.Beige;
        public string Family = "Times New Roman";
        public float Size = 12;
        public bool Bold = false;
        public bool Underline = false;
        public bool Strikeout = false;
        public bool Italic = false;

        [Header("Line Settings")]
        public float LineHeight = 4f;

        [Header("Wrapping Settings")]
        public bool WrapText = false;
        public float WrapAfter = 500f;
        public bool ShowWrap = false;


        public float TrueSize()
        {
            return (float)(Size * (Math.Sqrt(Math.Pow(GameObject.Transform.Scale.X, 2) + Math.Pow(GameObject.Transform.Scale.Y, 2)) / 2 + 0.3f));
        }


        Font Font = new Font("Times New Roman", 12);
        public Font GetFont() => Font;

        public override void Begin()
        {

        }

        public override void Render(Graphics g, int max_width, int max_height)
        {
            PointF pos = Surface.RenderSpace == RenderSpace.World ?
                new PointF(Transform.Position.X, Transform.Position.Y) :
                new PointF(Transform.Position.X, -Transform.Position.Y);

            var container = g.BeginContainer();

            SizeF textSize = g.MeasureString(Text, Font);

            var ox = textSize.Width / 2;
            var oy = textSize.Height / 2;

            var ro = g.RenderingOrigin;
            if (Surface.RenderSpace == RenderSpace.Screen)
            {
                g.TranslateTransform(0, 0);
            }
            else
            {
                g.TranslateTransform(pos.X, pos.Y);
            }

            g.RotateTransform(GameObject.Transform.Rotation);

            List<string> textParts = new List<string>();
            float py = pos.Y;

            var textSep = Text;

            if (WrapText)
            {
                while (!string.IsNullOrEmpty(textSep))
                {
                    var res = textSep.GetStringForMaxLength(WrapAfter, g, Font, out textSep);
                    textParts.Add(res);

                    if (Text == textSep)
                    {
                        break;
                    }
                }
            }
            else
            {
                textParts.Add(textSep);
            }

            if (ShowWrap)
            {
                g.DrawLine(Pens.Black, new PointF(pos.X, pos.Y), new PointF(pos.X + ((float)Font.Unit / 2) * WrapAfter, pos.Y));
                g.DrawLine(Pens.White, new PointF(pos.X, pos.Y + 3), new PointF(pos.X + ((float)Font.Unit / 2) * WrapAfter, pos.Y + 3));
            }

            foreach (var text in textParts)
            {
                g.DrawString(text, Font, new SolidBrush(Color), pos.X, py);

                py += g.MeasureString(text, Font).Height + LineHeight;
            }

            if (Surface.RenderSpace == RenderSpace.Screen)
            {
                g.TranslateTransform(ro.X, ro.Y);
            }
            else
            {
                g.TranslateTransform(-(pos.X), -(pos.Y));
            }


            g.EndContainer(container);
        }

        public override void Tick()
        {
            Surface = GameObject.GetComponentOfType<Canvas>(true);

            FontStyle style = FontStyle.Regular;

            if (Bold && Underline && Italic && Strikeout) style = FontStyle.Bold | FontStyle.Underline | FontStyle.Italic | FontStyle.Strikeout;
            else if (Bold && Underline && Italic) style = FontStyle.Bold | FontStyle.Underline | FontStyle.Italic;
            else if (Bold && Italic && Strikeout) style = FontStyle.Bold | FontStyle.Italic | FontStyle.Strikeout;
            else if (Bold && Underline && Strikeout) style = FontStyle.Bold | FontStyle.Underline | FontStyle.Strikeout;
            else if (Underline && Italic && Strikeout) style = FontStyle.Underline | FontStyle.Italic | FontStyle.Strikeout;
            else if (Bold && Italic) style = FontStyle.Bold | FontStyle.Italic;
            else if (Bold && Underline) style = FontStyle.Bold | FontStyle.Underline;
            else if (Underline && Italic) style = FontStyle.Underline | FontStyle.Italic;
            else if (Bold && Strikeout) style = FontStyle.Bold | FontStyle.Strikeout;
            else if (Italic && Strikeout) style = FontStyle.Italic | FontStyle.Strikeout;
            else if (Underline && Strikeout) style = FontStyle.Underline | FontStyle.Strikeout;
            else if (Bold) style = FontStyle.Bold;
            else if (Underline) style = FontStyle.Underline;
            else if (Strikeout) style = FontStyle.Strikeout;
            else if (Italic) style = FontStyle.Italic;

            Font = new Font(Family, TrueSize(), style);
        }
    }
}
