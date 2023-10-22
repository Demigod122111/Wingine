using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wingine.Helpers;
using Wingine.UI;

namespace Wingine
{

    [Serializable]
    public partial class Application : Form
    {
        public struct RenderSource
        {
            public readonly PictureBox RenderPlane;
            public Bitmap CurrentBuffer { get; private set; }
            public Bitmap BackBuffer { get; private set; }
            public Bitmap FrontBuffer { get; private set; }

            public bool UseCustomCamera;
            public Camera CustomCamera;

            public RenderSource(PictureBox renderPlane, int resolution_width, int resoultion_height)
            {
                RenderPlane = renderPlane;
                BackBuffer = new Bitmap(resolution_width, resoultion_height);
                FrontBuffer = new Bitmap(BackBuffer);
                CurrentBuffer = FrontBuffer;

                UseCustomCamera = false;
                CustomCamera = null;
            }

            public Graphics GetWritableBuffer() => CurrentBuffer == BackBuffer ? Graphics.FromImage(FrontBuffer) : Graphics.FromImage(BackBuffer);

            public void SwapBuffers()
            {
                CurrentBuffer = CurrentBuffer == BackBuffer ? FrontBuffer : BackBuffer;

                RenderPlane.Image = CurrentBuffer;
            }

            public void InitBuffers(int resolution_width, int resoultion_height)
            {
                BackBuffer = new Bitmap(resolution_width, resoultion_height);
                FrontBuffer = new Bitmap(BackBuffer);
                CurrentBuffer = FrontBuffer;
            }
        }

        public RenderSource renderSource;
        

        public static int RESOLUTION = 100; // 1440000 Unit Pixels
        public static int RESOLUTION_WIDTH => 16 * RESOLUTION;
        public static int RESOLUTION_HEIGHT => 9 * RESOLUTION;

        public Scene CurrentScene;

        internal PhysicsEngine PhysicsEngine = new PhysicsEngine();

        static Application()
        {
            
        }

        public Application()
        {
            InitializeComponent();

            Display.MouseDown += (s, e) =>
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        Input.LeftMouse = true;
                        break;
                    case MouseButtons.None:
                        break;
                    case MouseButtons.Right:
                        Input.RightMouse = true;
                        break;
                    case MouseButtons.Middle:
                        break;
                    case MouseButtons.XButton1:
                        break;
                    case MouseButtons.XButton2:
                        break;
                    default:
                        break;
                }
            };

            Display.MouseUp += (s, e) =>
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        Input.LeftMouse = false;
                        break;
                    case MouseButtons.None:
                        break;
                    case MouseButtons.Right:
                        Input.RightMouse = false;
                        break;
                    case MouseButtons.Middle:
                        break;
                    case MouseButtons.XButton1:
                        break;
                    case MouseButtons.XButton2:
                        break;
                    default:
                        break;
                }
            };


            Development();
        }

        ~Application()
        {
            GC.Collect();
        }


        bool doneRender = true;
        public void Render(RenderSource source)
        {
            if (!doneRender) return;
            doneRender = false;

            var rmp = PointToVector(Display.PointToClient(MousePosition));
            Input.MousePosition = new Vector2(rmp.X * Math.Abs((RESOLUTION_WIDTH / (float)Display.Width)), rmp.Y * Math.Abs((RESOLUTION_HEIGHT / (float)Display.Height)));

            Graphics g = source.GetWritableBuffer();

            Camera mainCamera = null;

            if (source.UseCustomCamera)
            {
                mainCamera = source.CustomCamera;
            }
            else
            {
                mainCamera = Camera.Main;
            }

            if (mainCamera == null || (!source.UseCustomCamera && (!mainCamera.GameObject.ActiveInHierarchy() || !mainCamera.Enabled)))
            {
                g.Clear(Color.Black);
                g.DrawString(
                    "No Rendering Camera",
                    new Font("Arial", 24, FontStyle.Bold),
                    Brushes.White,
                    new Point((int)(RESOLUTION_WIDTH / 2 - 17.5f * (19 / 2)), RESOLUTION_HEIGHT / 2 - 20));
                source.SwapBuffers();
                doneRender = true;
                return;
            }

            g.Clear(mainCamera.BackgroundColor);

            var cameraScale = mainCamera.Transform.GetScale();
            g.ScaleTransform(cameraScale.X, cameraScale.Y);
            var cameraPosition = mainCamera.Transform.GetPosition();
            g.TranslateTransform(-cameraPosition.X, cameraPosition.Y);

            var gameObjects = CurrentScene.GameObjects;
            var goCount = gameObjects.Count;

            List<Canvas> all_canvas = new List<Canvas>();

            for (int i = 0; i < goCount; i++)
            {
                var go = gameObjects[i];

                if (!go.ActiveInHierarchy()) continue;
                if (!mainCamera.WithinBounds(go.Transform.GetPosition())) continue;

                var origin = g.RenderingOrigin;
                g.RenderingOrigin = VectorToPoint(go.Transform.Position);

                var container = g.BeginContainer();

                #region Pixel Renderer
                if (go.ComponentExists<PixelRenderer>())
                {
                    PixelRenderer r = go.GetComponentOfType<PixelRenderer>();

                    try
                    {
                        g.TranslateTransform(go.Transform.GetPosition().X, -go.Transform.GetPosition().Y);

                        var scale = go.Transform.GetScale();
                        g.ScaleTransform(scale.X, scale.Y);
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }

                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    var pixels = r.Pixels;
                    var pixelsCount = pixels.Count;

                    for (int j = 0; j < pixelsCount; j++)
                    {
                        var pixel = pixels[j];

                        Vector2 pos = go.Transform.GetPosition();
                        Point point = new Point((int)(pos.X + pixel.Item1.X), (int)(-pos.Y + pixel.Item1.Y));
                        PointF pointf = new PointF((pos.X + pixel.Item1.X), (-pos.Y + pixel.Item1.Y));

                        switch (pixel.Item3)
                        {
                            case PixelType.Rectangle:
                                if (pixel.Item4 == FillType.Fill)
                                    g.FillRectangle(new SolidBrush(pixel.Item2), new RectangleF(pointf, new SizeF(r.PixelSize.X, r.PixelSize.Y)));
                                else if (pixel.Item4 == FillType.Empty)
                                    g.DrawRectangle(new Pen(new SolidBrush(pixel.Item2)), new Rectangle(point, new Size((int)r.PixelSize.X, (int)r.PixelSize.Y)));
                                break;
                            case PixelType.Circle:
                                if (pixel.Item4 == FillType.Fill)
                                    g.FillEllipse(new SolidBrush(pixel.Item2), new RectangleF(pointf, new SizeF(r.PixelSize.X, r.PixelSize.Y)));
                                else if (pixel.Item4 == FillType.Empty)
                                    g.DrawEllipse(new Pen(new SolidBrush(pixel.Item2)), new RectangleF(pointf, new SizeF(r.PixelSize.X, r.PixelSize.Y)));
                                break;
                            default:
                                break;
                        }
                    }
                }
                #endregion

                #region Sprite Renderer
                if (go.ComponentExists<SpriteRenderer>())
                {
                    SpriteRenderer r = go.GetComponentOfType<SpriteRenderer>();

                    try
                    {
                        g.TranslateTransform(go.Transform.GetPosition().X, -go.Transform.GetPosition().Y);

                        var scale = go.Transform.GetScale();
                        g.ScaleTransform(scale.X, scale.Y);
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }

                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    Bitmap img = r.GetImage();

                    var subContainer = g.BeginContainer();

                    var ox = img.Width / 2;
                    var oy = img.Height / 2;
                    var pos = go.Transform.Position;

                    g.TranslateTransform(pos.X + ox, pos.Y - oy);

                    g.DrawImage(RotateImage(img, go.Transform.Rotation), VectorToPointF(pos - new Vector2(ox, oy) - new Vector2(img.Width / 2, -(img.Height / 2))));

                    g.TranslateTransform(-(pos.X + ox), -(pos.Y - oy));

                    g.EndContainer(subContainer);
                }
                #endregion

                #region PhysicsBody Debugger
                    if (go.ComponentExists<PhysicsBody>())
                {
                    var cld = go.GetComponentOfType<PhysicsBody>();
                    var cldp = cld.BoundingBox;

                    if (cld.showBoundingBox)
                    {
                        g.DrawRectangle(
                            new Pen(new SolidBrush(Color.RoyalBlue), 5),
                            new Rectangle((int)cldp.X, (int)-cldp.Y, (int)cldp.Width, (int)cldp.Height));
                    }

                }
                #endregion

                g.EndContainer(container);
                g.TranslateTransform(-cameraPosition.X, cameraPosition.Y);

                #region UI - Canvas
                if (go.ComponentExists<Canvas>())
                {
                    var canvas = go.GetComponentOfType<Canvas>();
                    all_canvas.Add(canvas);
                }
                #endregion

                //g.RenderingOrigin = origin;
            }

            for (int i = 0; i < all_canvas.Count; i++)
            {
                var canvas = all_canvas[i];
                
                var ui_g = canvas.RenderSpace == RenderSpace.Screen ? source.GetWritableBuffer() : g;

                var ui_comps = canvas.GetUIComponents();

                ui_comps.Sort(new IUIGameObjectComparer());
                ui_comps.Sort(new IUIComponentComparer());
                // ui_comps = ui_comps.OrderBy(c => CurrentScene.GameObjects.IndexOf(c.GameObject)).ThenBy(c => c.RenderOrder).ToList();

                for (int ui_i = 0; ui_i < ui_comps.Count; ui_i++)
                {
                    var ui_e = ui_comps[ui_i];

                    ui_e.Render(ui_g, RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
                }
            }

            source.SwapBuffers();
            doneRender = true;
        }


        void Development()
        {

        }

        public static event EventHandler OnGameUpdate;

        bool firstFrame = true;
        internal void UpdateGame()
        {
            OnGameUpdate?.Invoke(this, null);

            for (int i = 0; i < CurrentScene.GameObjects.Count; i++)
            {
                var b = CurrentScene.GameObjects[i];

                b.CheckID();

                if (!b.ActiveInHierarchy()) continue;

                if (!IsRunning) break;

                var comps = b.GetComponents();
                for (int ii = 0; ii < comps.Count; ii++)
                {
                    var comp = comps[ii];

                    if (!IsRunning) break;

                    if (!comp.Enabled) continue;

                    if (comp is IUIComponent)
                    {
                        (comp as IUIComponent).MainThreadTick();
                    }

                    if (firstFrame)
                    {
                        comp.Began = false;
                    }

                    IFHelper.IFStateDo(ref comp.Began, () =>
                    {
                        comp.Begin();
                    }, false, true);

                    if (comp is Script)
                    {
                        var mb = ((Script)comp);

                        if (firstFrame) mb.Start();

                        bool justAwake = !mb.Awaked;

                        if (!mb.Awaked)
                        {
                            mb.Awaked = true;
                            mb.Awake();
                        }

                        mb.Update();

                    }
                    else if (comp is MonoBehaviour)
                    {
                        var mb = ((MonoBehaviour)comp);

                        if (firstFrame)
                        {
                            try
                            {
                                mb.Start();
                            }
                            catch (Exception e)
                            {
                                Debug.Write($"{e.Message} |[{e.Source}]|", Debug.DebugType.Error);
                            }
                        }

                        if (!mb.Awaked)
                        {
                            mb.Awaked = true;
                            try
                            {
                                mb.Awake();
                            }
                            catch (Exception e)
                            {
                                Debug.Write($"{e.Message} |[{e.Source}]|", Debug.DebugType.Error);
                            }
                        }


                        try
                        {
                            mb.Update();
                        }
                        catch (Exception e)
                        {
                            Debug.Write($"{e.Message} |[{e.Source}]|", Debug.DebugType.Error);
                        }

                    }
                }
            }

            firstFrame = false;
        }

        internal void FixedUpdate()
        {
            if (CurrentScene == null) return;

            for (int i = 0; i < CurrentScene.GameObjects.Count; i++)
            {
                var b = CurrentScene.GameObjects[i];

                if (!b.ActiveInHierarchy()) continue;
                var comps = b.GetScripts();

                for (int j = 0; j < comps.Count; j++)
                {
                    var comp = comps[j];

                    if (!comp.Enabled) continue;

                    try
                    {
                        comp.FixedUpdate();
                    }
                    catch (Exception e)
                    {
                        Debug.Write($"{e.Message} |[{e.Source}]|", Debug.DebugType.Error);
                    }
                }
            }
        }

        public bool IsRunning => running;

        public void Start()
        {
            firstFrame = true;

            ShouldDoRendering = true;
            DoRenderLoop();

            RunGameLoop();
        }

        public void Stop()
        {
            running = false;
            ShouldDoRendering = false;
        }

        private void Application_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
            if (Runner.InEditor)
            {
                Hide();
                e.Cancel = true;

            }
        }

        bool running = false;
        DateTime previousTime = DateTime.Now;
        internal double dt = 0;

        public static int TARGET_FPS = 60;

        async void DoTicks()
        {
            while (running)
            {
                if (CurrentScene == null) return;

                for (int i = 0; i < CurrentScene.GameObjects.Count; i++)
                {
                    var b = CurrentScene.GameObjects[i];

                    if (!b.ActiveInHierarchy()) continue;

                    b.Tick();

                    await Task.Delay(500);
                }
            }
        }

        async void RunGameLoop()
        {
            running = true;

            #region Physics Loop
            PhysicsEngine = new PhysicsEngine();
            async void PhysicsLoop()
            {
                while (running)
                {
                    await Task.Delay((int)(1000 * Time.FixedDeltaTime));

                    PhysicsEngine.UpdatePhysics(Time.FixedDeltaTime);
                    //Runner.App.FixedUpdate();
                }
            }


            new Thread(new ThreadStart(() => { PhysicsLoop(); })).Start();
            #endregion

            #region Ticking Loop
            DoTicks();
            #endregion

            while (running)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan deltaTime = currentTime - previousTime;
                previousTime = currentTime;
                dt = deltaTime.TotalSeconds;

                UpdateGame();

                await Task.Delay(1000 / TARGET_FPS);
            }
        }

        internal bool ShouldDoRendering = true;
        internal int renderStep = (int) (1000f / (TARGET_FPS * 1.2f));
        private async void DoRenderLoop()
        {
            renderSource = new RenderSource(Display, RESOLUTION_WIDTH, RESOLUTION_HEIGHT);

            while (ShouldDoRendering)
            {
                try
                {
                    Render(renderSource);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message, Debug.DebugType.Error);
                }
                await Task.Delay(renderStep);
            }
        }

        private Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width * 2, bmp.Height * 2);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width, bmp.Height);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width, -bmp.Height);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(bmp.Width / 2, bmp.Height / 2));
            }

            return rotatedImage;
        }
        public static Point VectorToPoint(Vector2 vector, float ox = 0f, float oy = 0f) => new Point((int)vector.X, (int)-vector.Y);
        public static Size VectorToSize(Vector2 vector, float ox = 0f, float oy = 0f) => new Size((int)vector.X, (int)vector.Y);
        public static PointF VectorToPointF(Vector2 vector, float ox = 0f, float oy = 0f) => new PointF((float)vector.X, (float)-vector.Y);
        public static SizeF VectorToSizeF(Vector2 vector, float ox = 0f, float oy = 0f) => new SizeF((float)vector.X, (float)vector.Y);

        public static Vector2 PointToVector(Point point, float ox = 0f, float oy = 0f) => new Vector2(point.X, -point.Y);
        public static Vector2 SizeToVector(Size size, float ox = 0f, float oy = 0f) => new Vector2(size.Width, size.Height);
        public static Vector2 PointFToVector(PointF point, float ox = 0f, float oy = 0f) => new Vector2(point.X, -point.Y);
        public static Vector2 SizeFToVector(SizeF size, float ox = 0f, float oy = 0f) => new Vector2(size.Width, size.Height);
    }
}

