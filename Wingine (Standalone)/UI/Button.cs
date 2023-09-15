using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Wingine.UI
{
    [Serializable]
    public class Button : IUIComponent
    {
        public Vector2 Size = new Vector2(120, 30);

        public Color Normal = Color.Black;
        public Color Pressed = Color.DarkGray;


        Color color = Color.Black;

        public delegate void ButtonClickEventArgs();
        public event ButtonClickEventArgs OnClick;

        bool IsClicking = false;

        bool IsOnCooldown = false;

        public static int ClickTime = 10;

        RectangleF rectangle = RectangleF.Empty;
        RectangleF mouse_rectangle = RectangleF.Empty;

        public override void Render(Graphics g, int max_width, int max_height)
        {
            var brush = new SolidBrush(color);
            
            PointF pos = Surface.RenderSpace == RenderSpace.World ?
                new PointF(Transform.Position.X, Transform.Position.Y) :
                new PointF(Transform.Position.X, -Transform.Position.Y);

            var rect = new RectangleF(pos, Application.VectorToSizeF(Size));
            rectangle = rect;

            var mpos = Application.VectorToPointF(Input.MousePosition);
            mouse_rectangle = new RectangleF(mpos.X, mpos.Y, 2, 2);

            g.FillRectangle(brush, rect);
        }

        public override void Begin()
        {
            new Thread(new ThreadStart(AwaitClick)).Start();
        }

        public override void Tick()
        {
            color = Normal;
            Surface = GameObject.GetComponentOfType<Canvas>(true);
        }

        public override void MainThreadTick()
        {
            if (Runner.App.IsRunning)
            {
                left_down = Input.IsMouseButtonDown(Input.MouseButton.Left);
            }
        }

        bool left_down = false;

        async void AwaitClick()
        {
            while (Runner.App.IsRunning)
            {
                if (!IsOnCooldown && left_down)
                {
                    if (mouse_rectangle.IntersectsWith(rectangle))
                    {
                        IsOnCooldown = true;

                        color = Pressed;

                        try
                        {
                            if (OnClick != null) OnClick();
                        }
                        catch (Exception e)
                        {
                            Debug.Write(e.Message, Debug.DebugType.Error);
                        }

                        await Task.Delay(ClickTime);
                        color = Normal;
                        IsOnCooldown = false;
                    }
                }
            }
        }
    }
}
