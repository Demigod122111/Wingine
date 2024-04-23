﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wingine.Helpers;
using Wingine.UI;
using Wingine.Video;

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

            public bool doneRender;

            public RenderSource(PictureBox renderPlane, int resolution_width, int resoultion_height)
            {
                RenderPlane = renderPlane;
                BackBuffer = new Bitmap(resolution_width, resoultion_height);
                FrontBuffer = new Bitmap(BackBuffer);
                CurrentBuffer = FrontBuffer;

                UseCustomCamera = false;
                CustomCamera = null;

                doneRender = true;
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


        public unsafe void Render(RenderSource source)
        {
            if (!source.doneRender) return;
            source.doneRender = false;

            var rmp = PointToVector(Display.PointToClient(MousePosition));
            Input.MousePosition = new Vector2(rmp.X * Math.Abs((RESOLUTION_WIDTH / (float)Display.Width)), rmp.Y * Math.Abs((RESOLUTION_HEIGHT / (float)Display.Height)));

            Graphics g = source.GetWritableBuffer();

            Camera mainCamera = Camera.Main;

            if (source.UseCustomCamera)
            {
                mainCamera = source.CustomCamera;
            }

            void DrawNoRender()
            {
                g.Clear(Color.Black);
                g.DrawString(
                    "No Rendering Camera",
                    new Font("Arial", 24, FontStyle.Bold),
                    Brushes.White,
                    new Point((int)(RESOLUTION_WIDTH / 2 - 17.5f * (19 / 2)), RESOLUTION_HEIGHT / 2 - 20));
                source.SwapBuffers();
                source.doneRender = true;
            }

            if (!source.UseCustomCamera)
            {
                if (mainCamera == null || !mainCamera.GameObject.ActiveInHierarchy() || !mainCamera.Enabled)
                {
                    DrawNoRender();
                    return;
                }
            }
            else
            {
                if (mainCamera == null)
                {
                    DrawNoRender();
                    return;
                }
            }

            g.Clear(mainCamera.BackgroundColor);

            var cameraScale = mainCamera.Transform.GetScale();
            g.ScaleTransform(cameraScale.X, cameraScale.Y);
            var cameraPosition = mainCamera.Transform.GetPosition();
            g.TranslateTransform(-cameraPosition.X, cameraPosition.Y);

            var gameObjects = CurrentScene.GameObjects;
            var goCount = gameObjects.Count;

            List<IntPtr> all_canvas = new List<IntPtr>();

            for (int i = 0; i < goCount; i++)
            {
                var go = gameObjects[i];

                if (!go.ActiveInHierarchy()) continue;

                #region UI - Canvas
                if (go.ComponentExists<Canvas>())
                {
                    var canvas = go.GetComponentOfType<Canvas>();
                    all_canvas.Add((IntPtr)(&canvas));
                }
                #endregion

                if (!mainCamera.WithinBounds(go.Transform.GetPosition())) continue;

                var origin = g.RenderingOrigin;
                g.RenderingOrigin = VectorToPoint(go.Transform.Position);

                var container = g.BeginContainer();

                #region Pixel Renderer
                if (go.ComponentExists<PixelRenderer>())
                {
                    List<PixelRenderer> rs = go.GetComponentsOfType<PixelRenderer>().Cast<PixelRenderer>().ToList();

                    foreach (var r in rs)
                    {
                        if (!r.Enabled) continue;

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

                }
                #endregion

                #region Sprite Renderer
                if (go.ComponentExists<SpriteRenderer>())
                {
                    List<SpriteRenderer> rs = go.GetComponentsOfType<SpriteRenderer>().Cast<SpriteRenderer>().ToList();

                    foreach (var r in rs)
                    {
                        if (!r.Enabled) continue;

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
                }
                #endregion

                #region Video Player
                if (go.ComponentExists<VideoPlayer>())
                {
                    List<VideoPlayer> vps = go.GetComponentsOfType<VideoPlayer>().Cast<VideoPlayer>().ToList();

                    foreach (var vp in vps)
                    {
                        if (!vp.Enabled) continue;

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

                        Bitmap img = vp.GetCurrentFrame();

                        if (img == null)
                        {
                            img = new Bitmap(vp.ResolutionWidth, vp.ResolutionHeight);
                            Graphics.FromImage(img).Clear(Color.Black);
                            Graphics.FromImage(img).DrawRectangle(Pens.Gray, new Rectangle(0, 0, vp.ResolutionWidth, vp.ResolutionHeight));
                        }

                        var subContainer = g.BeginContainer();

                        var ox = img.Width / 2;
                        var oy = img.Height / 2;
                        var pos = go.Transform.Position;

                        g.TranslateTransform(pos.X + ox, pos.Y - oy);

                        g.DrawImage(RotateImage(img, go.Transform.Rotation), VectorToPointF(pos - new Vector2(ox, oy) - new Vector2(img.Width / 2, -(img.Height / 2))));

                        g.TranslateTransform(-(pos.X + ox), -(pos.Y - oy));

                        g.EndContainer(subContainer);
                    }
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
                //g.TranslateTransform(-cameraPosition.X, cameraPosition.Y);

                //g.RenderingOrigin = origin;
            }

            for (int i = 0; i < all_canvas.Count; i++)
            {
                var canvas = *((Canvas*)all_canvas[i]);
                
                var ui_g = canvas.RenderSpace == RenderSpace.Screen ? source.GetWritableBuffer() : g;

                if (ui_g == g)
                {
                    if (!mainCamera.WithinBounds(canvas.Transform.GetPosition())) continue;
                }

                var ui_comps = canvas.GetUIComponents();

                ui_comps.Sort(new IUIGameObjectComparer());
                ui_comps.Sort(new IUIComponentComparer());
                // ui_comps = ui_comps.OrderBy(c => CurrentScene.GameObjects.IndexOf(c.GameObject)).ThenBy(c => c.RenderOrder).ToList();

                for (int ui_i = 0; ui_i < ui_comps.Count; ui_i++)
                {
                    var ui_e = ui_comps[ui_i];

                    if (!ui_e.Enabled) continue;

                    ui_e.Render(ui_g, RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
                }
            }

            source.SwapBuffers();
            source.doneRender = true;
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

                        var inputThread = new Thread(new ThreadStart(mb.Input));
                        inputThread.SetApartmentState(ApartmentState.STA);
                        inputThread.Start();

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

                var gos = CurrentScene.GameObjects;

                for (int i = 0; i < gos.Count; i++)
                {
                    var b = gos[i];

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
                    Runner.App.FixedUpdate();
                }
            }


            new Thread(new ThreadStart(() => { PhysicsLoop(); })).Start();
            #endregion

            #region Ticking Loop
            new Thread(new ThreadStart(() => { DoTicks(); })).Start();
            #endregion

            #region Diagnostics
            void RegulateThreads()
            {
                var cp = Process.GetCurrentProcess();

                if (true)
                {

                    var threads = cp.Threads;

                    string r = "";

                    r += "Virtual Memory (Size64): " + cp.VirtualMemorySize64.ToString() + "\n\n---\n\n";

                    for (int i = 0; i < threads.Count; i++)
                    {
                        var thd = threads[i];

                        try
                        {
                            if (thd.TotalProcessorTime.TotalSeconds == 0)
                            {
                                thd.Dispose();
                                continue;
                            }

                            if ((thd.ThreadState == System.Diagnostics.ThreadState.Wait && thd.WaitReason == ThreadWaitReason.Unknown)
                                || thd.ThreadState == System.Diagnostics.ThreadState.Unknown
                                || thd.ThreadState == System.Diagnostics.ThreadState.Terminated)
                            {
                                thd.Dispose();
                                continue;
                            }

                            r += $"{thd.Id} - {thd.TotalProcessorTime.TotalSeconds}s\n\n";
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }

            new Thread(new ThreadStart(() => { RegulateThreads(); })).Start();

            void ManageMemory()
            {
                GC.AddMemoryPressure(Process.GetCurrentProcess().WorkingSet64);
                // Perform garbage collection
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            new Thread(new ThreadStart(() => { ManageMemory(); })).Start();
            #endregion

            while (running)
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan deltaTime = currentTime - previousTime;
                previousTime = currentTime;
                dt = deltaTime.TotalSeconds;

                Input.InApp = ((IsRunning) && (Focused));
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

