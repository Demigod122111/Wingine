using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingine.UI
{
    [Serializable]
    public class Text : IUIComponent
    {
        public string text = "";

        [Header("Font Settings")]
        [ExtendColor]
        public Color Color = Color.Beige;
        public string Family = "Times New Roman";
        public float Size = 12;
        public bool Bold = false;
        public bool Underline = false;
        public bool Strikeout = false;
        public bool Italic = false;
        

        
        Font font = new Font("Times New Roman", 12);
        public Font GetFont() => font;

        public override void Begin()
        {
            
        }

        public override void Render(Graphics g, int max_width, int max_height)
        {
            g.DrawString(text, font, new SolidBrush(Color), new PointF(Transform.Position.X, Transform.Position.Y));
        }

        public override void Tick()
        {
            Surface = GameObject.GetComponent<Canvas>(true);

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

            font = new Font(Family, Size, style);
        }
    }
}
