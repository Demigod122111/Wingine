using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public static int RESOLUTION_WIDTH = 800;
        public static int RESOLUTION_HEIGHT = 600;

        public Scene CurrentScene;

        static Application()
        {
            InitBuffers();
        }

        public Application()
        {
            InitializeComponent();
            RenderPlanes.Add(Display);

            Development();
        }

        ~Application()
        {
            GC.Collect();
        }

        public void Render()
        {
            Graphics g = GetWritableBuffer();

            Camera mainCamera = Camera.Main;

            if (mainCamera == null || !mainCamera.GameObject.ActiveInHierarchy() || !mainCamera.Enabled)
            {
                g.Clear(Color.Black);
                g.DrawString("No Rendering Camera",
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

                if (!go.ActiveInHierarchy()) return;
                if (!mainCamera.WithinBounds(go.Transform.Position)) return;

                var origin = g.RenderingOrigin;
                var container = g.BeginContainer();

                #region Renderer
                if (go.ComponentExists<PixelRenderer>())
                {
                    try
                    {
                        g.RotateTransform((float)go.Transform.Rotation);
                        var scale = go.Transform.GetScale();
                        g.ScaleTransform(scale.X, scale.Y);
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }

                    PixelRenderer r = go.GetComponent<PixelRenderer>();

                    var extreme = r.GetExtreme();

                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.RenderingOrigin = new Point((int)go.Transform.Position.X, (int)go.Transform.Position.Y);

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
                                    g.FillRectangle(Brushes.White, new RectangleF(pointf, new SizeF(r.PixelSize.X, r.PixelSize.Y)));
                                else if (pixel.Item4 == FillType.Empty)
                                    g.DrawRectangle(Pens.White, new Rectangle(point, new Size((int)r.PixelSize.X, (int)r.PixelSize.Y)));
                                break;
                            case PixelType.Circle:
                                if (pixel.Item4 == FillType.Fill)
                                    g.FillEllipse(Brushes.White, new RectangleF(pointf, new SizeF(r.PixelSize.X, r.PixelSize.Y)));
                                else if (pixel.Item4 == FillType.Empty)
                                    g.DrawEllipse(Pens.White, new RectangleF(pointf, new SizeF(r.PixelSize.X, r.PixelSize.Y)));
                                break;
                            default:
                                break;
                        }
                    }
                }
                #endregion

                g.EndContainer(container);

                #region UI - Canvas
                if (go.ComponentExists<Canvas>())
                {
                    var canvas = go.GetComponent<Canvas>();
                    if (canvas.Enabled)
                    {
                        var canvasContainer = g.BeginContainer();

                        var uiComponents = canvas.GetUIComponents();
                        uiComponents.Sort(new IUIComponentComparer());

                        var uiComponentsCount = uiComponents.Count;
                        for (int j = 0; j < uiComponentsCount; j++)
                        {
                            var uiComponent = uiComponents[j];
                            uiComponent.Render(g, RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
                        }

                        g.EndContainer(canvasContainer);
                    }
                }
                #endregion

                g.RenderingOrigin = origin;
            }

            SwapBuffers();
        }

        public Graphics GetWritableBuffer() => CurrentBuffer == BackBuffer ? Graphics.FromImage(FrontBuffer) : Graphics.FromImage(BackBuffer);

        public void SwapBuffers()
        {
            Bitmap buffer = CurrentBuffer == BackBuffer ? FrontBuffer : BackBuffer;
            CurrentBuffer = buffer;

            foreach (var renderPlane in RenderPlanes)
            {
                renderPlane.Image = buffer;
            }
        }

        static void InitBuffers()
        {
            BackBuffer = new Bitmap(RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
            FrontBuffer = new Bitmap(BackBuffer);
            CurrentBuffer = FrontBuffer;
        }

        void Development()
        {

        }

        public void UpdateGame()
        {
            bool firstFrame = false;

            CurrentScene.GameObjects.ForEach((b) =>
            {
                if (!b.ActiveInHierarchy()) return;

                b.GetComponents().ForEach((comp) =>
                {
                    if (!comp.Enabled) return;

                    comp.Tick();

                    if (comp is MonoBehaviour)
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
                });
            });

            firstFrame = false;
        }

        public bool IsRunning => running;

        public void Start()
        {
            bool firstFrame = true;

            RunGameLoop();
            RenderLoop.Start();
        }

        public void Stop()
        {
            running = false;
            RenderLoop.Stop();
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

        public int TARGET_FPS = 1000;

        async void RunGameLoop()
        {
            running = true;
            while (running)
            {
                await Task.Delay(1000 / TARGET_FPS);

                DateTime currentTime = DateTime.Now;
                TimeSpan deltaTime = currentTime - previousTime;
                previousTime = currentTime;
                dt = deltaTime.TotalSeconds;

                UpdateGame();
            }
        }

        private void RenderLoop_Tick(object sender, EventArgs e)
        {
            try
            {
                Render();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message, Debug.DebugType.Error);
            }
        }
    }
}   

