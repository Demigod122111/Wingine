using System;
using System.Collections.Generic;
using System.Drawing;

namespace Wingine.UI
{
    [Serializable]
    public abstract class IUIComponent : IComponent
    {
        [HideInInspector]
        public Canvas Surface { get { return surface; } set { surface?.RemoveComponent(this); surface = value; surface?.AddComponent(this); } }
        Canvas surface;

        public int RenderOrder = 0;

        public abstract void Render(Graphics g, int max_width, int max_height);
        public virtual void MainThreadTick() { }

    }

    [Serializable]
    public class IUIComponentComparer : IComparer<IUIComponent>
    {
        public int Compare(IUIComponent x, IUIComponent y)
        {
            var xro = x.RenderOrder;
            var yro = y.RenderOrder;

            if (xro == 0 || yro == 0)
            {
                if (xro == 0)
                {
                    xro++;

                    if (yro == xro)
                    {
                        yro++;
                        if (yro == 0) yro++;
                    }
                }

                if (yro == 0)
                {
                    yro++;

                    if (xro == yro)
                    {
                        xro++;
                        if (xro == 0) xro++;
                    }
                }
            }

            return xro.CompareTo(yro);
        }
    }

    [Serializable]
    public class IUIGameObjectComparer : IComparer<IUIComponent>
    {
        public int Compare(IUIComponent x, IUIComponent y)
        {
            var xro = Runner.App.CurrentScene.GameObjects.IndexOf(x.GameObject);
            var yro = Runner.App.CurrentScene.GameObjects.IndexOf(y.GameObject);

            if (xro == 0 || yro == 0)
            {
                if (xro == 0)
                {
                    xro++;

                    if (yro == xro)
                    {
                        yro++;
                        if (yro == 0) yro++;
                    }
                }

                if (yro == 0)
                {
                    yro++;

                    if (xro == yro)
                    {
                        xro++;
                        if (xro == 0) xro++;
                    }
                }
            }

            return xro.CompareTo(yro);
        }
    }
}
