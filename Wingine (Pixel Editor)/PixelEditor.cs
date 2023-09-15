using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Wingine.PixelEditor
{
    public partial class PixelEditor : Form
    {
        int PixelWidth = 50;
        int PixelHeight = 50;

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
                RichTextBox_PixelData.Text = value;
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

                string[] data = Regex.Split(tpl, ",");
                try
                {
                    extractedPixels.Add(new Tuple<Vector2, Color, PixelType, FillType>(
                        new Vector2(double.Parse(data[0]), double.Parse(data[1])),
                        Color.FromArgb(int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])),
                        (PixelType)Enum.GetValues(typeof(PixelType)).GetValue(int.Parse(data[6])),
                        (FillType)Enum.GetValues(typeof(FillType)).GetValue(int.Parse(data[7]))));
                }
                catch
                {
                    //Debug.Write($"Each pixel in the Pixel Data should follow the format:\n[horizontal position, vertical position, alpha, red, green, blue, pixel_type, fill_type]\n and ends with a ';'", Debug.DebugType.Warning);
                }
            }
            return extractedPixels;
        }


        public List<Tuple<Vector2, Color, PixelType, FillType>> Pixels { get; private set; } = new List<Tuple<Vector2, Color, PixelType, FillType>>();


        static Bitmap CurrentBuffer;
        static Bitmap BackBuffer;
        static Bitmap FrontBuffer;

        public int RESOLUTION = 100; // 1440000 Unit Pixels
        public int RESOLUTION_WIDTH => 16 * RESOLUTION;
        public int RESOLUTION_HEIGHT => 9 * RESOLUTION;

        float vx => float.Parse(NumericUpDown_VX.Value.ToString());
        float vy => float.Parse(NumericUpDown_VY.Value.ToString());

        enum ToolType
        {
            Pencil,
            Eraser,
        }

        ToolType tool = ToolType.Pencil;

        internal Graphics GetWritableBuffer() => CurrentBuffer == BackBuffer ? Graphics.FromImage(FrontBuffer) : Graphics.FromImage(BackBuffer);

        internal void SwapBuffers()
        {
            CurrentBuffer = CurrentBuffer == BackBuffer ? FrontBuffer : BackBuffer;
            Canvas.Image = CurrentBuffer;
        }

        void InitBuffers()
        {
            BackBuffer = new Bitmap(RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
            FrontBuffer = new Bitmap(BackBuffer);
            CurrentBuffer = FrontBuffer;
        }

        public PixelEditor()
        {
            InitializeComponent();
            InitBuffers();
        }

        private void Render_Tick(object sender, EventArgs e)
        {
            RenderApp();
        }

        void RenderApp()
        {
            NumericUpDown_VX.Increment = PixelWidth;
            NumericUpDown_VY.Increment = PixelHeight;

            if (!NumericUpDown_VX.Focused) NumericUpDown_VX.Value = Math.Floor(NumericUpDown_VX.Value / PixelWidth) * PixelWidth;
            if (!NumericUpDown_VY.Focused) NumericUpDown_VY.Value = Math.Floor(NumericUpDown_VY.Value / PixelHeight) * PixelHeight;

            Graphics g = GetWritableBuffer();
            Graphics gg = GetWritableBuffer();

            g.Clear(ColorGrid_BG.Color);

            g.TranslateTransform(-vx, vy);

            if (CheckBox_ShowGrid.Checked)
            {
                var minX = (int)-Math.Pow((double)NumericUpDown_VX.Minimum, 2);
                minX = 0;

                var maxX = (int)Math.Pow((double)NumericUpDown_VX.Maximum, 2);
                maxX = RESOLUTION_WIDTH;

                var minY = (int)-Math.Pow((double)NumericUpDown_VY.Minimum, 2);
                minY = 0;

                var maxY = (int)Math.Pow((double)NumericUpDown_VY.Maximum, 2);
                maxY = RESOLUTION_HEIGHT;

                for (int x = minX; x < maxX; x += PixelWidth)
                {
                    gg.DrawLine(new Pen(ColorWheel_Grid.Color), new Point(x, minY), new Point(x, maxY));
                }

                for (int y = minY; y < maxY; y += PixelHeight)
                {
                    gg.DrawLine(new Pen(ColorWheel_Grid.Color), new Point(minX, y), new Point(maxX, y));
                }
            }



            for (int i = 0; i < Pixels.Count; i++)
            {
                var pixel = Pixels[i];
                var point = new Point((int)pixel.Item1.X, (int)pixel.Item1.Y);

                switch (pixel.Item3)
                {
                    case PixelType.Rectangle:
                        if (pixel.Item4 == FillType.Fill)
                        {
                            g.FillRectangle(new SolidBrush(pixel.Item2), new Rectangle(point, new Size(PixelWidth, PixelHeight)));
                        }
                        else if (pixel.Item4 == FillType.Empty)
                        {
                            g.DrawRectangle(new Pen(pixel.Item2), new Rectangle(point, new Size(PixelWidth, PixelHeight)));
                        }
                        break;
                    case PixelType.Circle:
                        if (pixel.Item4 == FillType.Fill)
                        {
                            g.FillEllipse(new SolidBrush(pixel.Item2), new Rectangle(point, new Size(PixelWidth, PixelHeight)));
                        }
                        else if (pixel.Item4 == FillType.Empty)
                        {
                            g.DrawEllipse(new Pen(pixel.Item2), new Rectangle(point, new Size(PixelWidth, PixelHeight)));
                        }
                        break;
                    default:
                        break;
                }
            }

            if (CheckBox_ShowGrid.Checked)
            {
                g.DrawEllipse(new Pen(ColorWheel_Grid.Color, 2), new RectangleF(-PixelWidth / 2, -PixelHeight / 2, PixelWidth, PixelHeight));
            }

            SwapBuffers();
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
            var mousePos = Canvas.PointToClient(MousePosition);

            var px = (double)(mousePos.X) / Canvas.Width;
            var py = (double)(mousePos.Y) / Canvas.Height;

            var x = (int)-(Math.Floor(-vx / PixelWidth) * PixelWidth) + (int)Math.Floor(RESOLUTION_WIDTH * px / PixelWidth) * PixelWidth;
            var y = (int)-(Math.Floor(vy / PixelWidth) * PixelHeight) + (int)Math.Floor(RESOLUTION_HEIGHT * py / PixelHeight) * PixelHeight;

            var fill = ComboBox_FillType.Text.Trim().ToLower() == "fill" ? 0 : (ComboBox_FillType.Text.Trim().ToLower() == "no fill" ? 1 : -1);
            var type = ComboBox_PixelType.Text.Trim().ToLower() == "rectangle" ? 0 : (ComboBox_PixelType.Text.Trim().ToLower() == "ellipsis" ? 1 : -1);

            var a = ColorEditor_Pixel.Color.A;
            var r = ColorEditor_Pixel.Color.R;
            var g = ColorEditor_Pixel.Color.G;
            var b = ColorEditor_Pixel.Color.B;


            switch (tool)
            {
                case ToolType.Pencil:
                    PixelData += $"{x},{y},{a},{r},{g},{b},{type},{fill};\n";
                    break;
                case ToolType.Eraser:
                    var SearchPixels = Regex.Split(PixelData, ";\n").ToList();
                    SearchPixels.Reverse();

                    foreach (var pixel in SearchPixels)
                    {
                        if (pixel.Trim().StartsWith($"{x},{y},"))
                        {
                            SearchPixels.Remove(pixel);
                            break;
                        }
                    }

                    SearchPixels.Reverse();
                    PixelData = string.Join(";\n", SearchPixels);
                    break;
                default:
                    break;
            }
        }

        private void ComboBox_Tool_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ComboBox_Tool.Text.Trim().ToLower())
            {
                case "pencil":
                    tool = ToolType.Pencil;
                    break;
                case "eraser":
                    tool = ToolType.Eraser;
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboBox_PixelType.SelectedIndex = 0;
            ComboBox_FillType.SelectedIndex = 0;
            ComboBox_Tool.SelectedIndex = 0;
            NumericUpDown_Resolution.Value = decimal.Parse(RESOLUTION.ToString());
        }

        private void RichTextBox_PixelData_TextChanged(object sender, EventArgs e)
        {
            if (PixelData != RichTextBox_PixelData.Text)
            {
                PixelData = RichTextBox_PixelData.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var k = PixelData;
            var x = PixelWidth;
            var y = PixelHeight;

            try
            {
                PixelData = "";
                PixelWidth = int.Parse(Interaction.InputBox("Enter Pixel Width: ", "New Canvas", "50"));
                PixelHeight = int.Parse(Interaction.InputBox("Enter Pixel Height: ", "New Canvas", "50"));
            }
            catch
            {
                PixelData = k;
                PixelWidth = x;
                PixelHeight = y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileFilter = "PNG Image Format (*.png)|*.png|Other Format (*.*)|*.*";
            var fsd = new SaveFileDialog();
            fsd.Filter = fileFilter;

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                CurrentBuffer.Save(fsd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileFilter = "Pixel Editor Graphics (*.peg)|*.peg|Other Format (*.*)|*.*";
            var fsd = new SaveFileDialog();
            fsd.Filter = fileFilter;

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                DataStore.WriteToBinaryFile(fsd.FileName, new PixelDataStorage() { PixelData = PixelData, PixelWidth = PixelWidth, PixelHeight = PixelHeight });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fileFilter = "Pixel Editor Graphics (*.peg)|*.peg";
            var fsd = new OpenFileDialog();
            fsd.Filter = fileFilter;

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                var pds = DataStore.ReadFromBinaryFile<PixelDataStorage>(fsd.FileName);

                var k = PixelData;
                var x = PixelWidth;
                var y = PixelHeight;

                try
                {
                    PixelData = pds.PixelData;
                    PixelWidth = pds.PixelWidth;
                    PixelHeight = pds.PixelHeight;
                }
                catch
                {
                    PixelData = k;
                    PixelWidth = x;
                    PixelHeight = y;
                }
            }
        }

        [Serializable]
        class PixelDataStorage
        {
            public int PixelWidth;
            public int PixelHeight;
            public string PixelData;
        }

        private void NumericUpDown_Resolution_ValueChanged(object sender, EventArgs e)
        {
            RESOLUTION = int.Parse(NumericUpDown_Resolution.Value.ToString());
            InitBuffers();
        }
    }
}
