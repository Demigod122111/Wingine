﻿using System;
using System.Drawing;

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

            g.DrawString(Text, Font, new SolidBrush(Color), pos);
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

            Font = new Font(Family, Size, style);
        }
    }
}