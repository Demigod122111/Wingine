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
        public List<PictureBox> RenderPlanes = new List<PictureBox>();

        static Bitmap CurrentBuffer;
        static Bitmap BackBuffer;
        static Bitmap FrontBuffer;

        public static int RESOLUTION = 100; // 1440000 Unit Pixels
        public static int RESOLUTION_WIDTH => 16 * RESOLUTION;
        public static int RESOLUTION_HEIGHT => 9 * RESOLUTION;

        public Scene CurrentScene;

        static Application()
        {
            InitBuffers();
        }

        public Application()
        {
            InitializeComponent();
            RenderPlanes.Add(Display);

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
        public void Render()
        {
            if (!doneRender) return;
            doneRender = false;

            var rmp = PointToVector(Display.PointToClient(MousePosition));
            Input.MousePosition = new Vector2(rmp.X * Math.Abs((RESOLUTION_WIDTH / (float)Display.Width)), rmp.Y * Math.Abs((RESOLUTION_HEIGHT / (float)Display.Height)));

            Graphics g = GetWritableBuffer();

            Camera mainCamera = Camera.Main;

            if (mainCamera == null || !mainCamera.GameObject.ActiveInHierarchy() || !mainCamera.Enabled)
            {
                g.Clear(Color.Black);
                g.DrawString(
                    "No Rendering Camera",
                    new Font("Arial", 24, FontStyle.Bold),
                    Brushes.White,
                    new Point((int)(RESOLUTION_WIDTH / 2 - 17.5f * (19 / 2)), RESOLUTION_HEIGHT / 2 - 20));
                SwapBuffers();
                return;
            }

            g.Clear(mainCamera.BackgroundColor);

            var cameraScale = mainCamera.Transform.GetScale();
            g.ScaleTransform(cameraScale.X, cameraScale.Y);
            var cameraPosition = mainCamera.Transform.GetPosition();
            g.TranslateTransform(-cameraPosition.X, cameraPosition.Y);

            var gameObjects = CurrentScene.GameObjects;
            var goCount = gameObjects.Count;

            for (int i = 0; i < goCount; i++)
            {
                var go = gameObjects[i];

                if (!go.ActiveInHierarchy()) continue;
                if (!mainCamera.WithinBounds(go.Transform.GetPosition())) continue;

                var origin = g.RenderingOrigin;
                g.RenderingOrigin = VectorToPoint(go.Transform.Position);

                var container = g.BeginContainer();

                #region Renderer
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

                    
                }
                #endregion

                #region Collision Debugger
                if (go.ComponentExists<Collider>())
                {
                    var cld = go.GetComponentOfType<Collider>();
                    var cldp = VectorToPoint(go.Transform.GetPosition(), -cld.Size.X, -cld.Size.Y);

                    if (cld.ShowBounds)
                    {
                        g.DrawRectangle(
                            new Pen(new SolidBrush(Color.RoyalBlue), 5),
                            new Rectangle(cldp, new Size((int)(cld.Size.X * 2), (int)(cld.Size.Y * 2))));
                    }

                    if (cld.ShowPhysicsData)
                    {
                        g.DrawString($"{go.Name}: {cld.frc}N ({cld.PhysicsBody.CapturedForce}) ", new Font("RomanC", 64), Brushes.Gold, new Point(cldp.X + 130, cldp.Y + 0));
                    }

                }
                #endregion

                g.EndContainer(container);
                g.TranslateTransform(-cameraPosition.X, cameraPosition.Y);

                #region UI - Canvas
                if (go.ComponentExists<Canvas>())
                {
                    var canvas = go.GetComponentOfType<Canvas>();
                    var ui_g = canvas.RenderSpace == RenderSpace.Screen ? GetWritableBuffer() : g;

                    var ui_comps = canvas.GetUIComponents();

                    ui_comps.Sort(new IUIComponentComparer());

                    for (int ui_i = 0; ui_i < ui_comps.Count; ui_i++)
                    {
                        var ui_e = ui_comps[ui_i];

                        ui_e.Render(ui_g, RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
                    }
                }
                #endregion

                //g.RenderingOrigin = origin;
            }

            SwapBuffers();
            doneRender = true;
        }

        internal Graphics GetWritableBuffer() => CurrentBuffer == BackBuffer ? Graphics.FromImage(FrontBuffer) : Graphics.FromImage(BackBuffer);

        internal void SwapBuffers()
        {
            CurrentBuffer = CurrentBuffer == BackBuffer ? FrontBuffer : BackBuffer;

            for (int i = 0; i < RenderPlanes.Count; i++)
            {
                RenderPlanes[i].Image = CurrentBuffer;
            }
        }

        public static void InitBuffers()
        {
            BackBuffer = new Bitmap(RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
            FrontBuffer = new Bitmap(BackBuffer);
            CurrentBuffer = FrontBuffer;
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
                var comps = b.GetComponents();

                for (int j = 0; j < comps.Count; j++)
                {
                    var comp = comps[j];

                    if (!comp.Enabled) continue;

                    if (comp is Script)
                    {
                        var mb = ((Script)comp);

                        mb.FixedUpdate();
                    }
                    else if (comp is MonoBehaviour)
                    {
                        var mb = ((MonoBehaviour)comp);
                        try
                        {
                            mb.FixedUpdate();
                        }
                        catch (Exception e)
                        {
                            Debug.Write($"{e.Message} |[{e.Source}]|", Debug.DebugType.Error);
                        }
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
            async void PhysicsLoop()
            {
                for (int i = 0; i < CurrentScene.GameObjects.Count; i++)
                {
                    var b = CurrentScene.GameObjects[i];

                    if (!b.ActiveInHierarchy()) break;

                    if (!IsRunning) break;

                    var comps = b.GetComponentsOfType<PhysicsBody>();
                    for (int ii = 0; ii < comps.Count; ii++)
                    {
                        var comp = comps[ii];

                        if (!comp.Enabled) break;
                        var pb = comp as PhysicsBody;

                        pb.Init();
                    }
                }

                PhysicsBody.PhysicsUpdate += () =>
                {
                    Runner.App.FixedUpdate();
                };

                while (running)
                {
                    await Task.Delay((int)(1000 * Time.FixedDeltaTime));

                    PhysicsBody.InternalPhysicsUpdate();
                }
            }


            //new Thread(new ThreadStart(() => { PhysicsLoop(); })).Start();
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
            while (ShouldDoRendering)
            {
                try
                {
                    Render();
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
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
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

