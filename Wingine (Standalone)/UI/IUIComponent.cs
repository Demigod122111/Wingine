using System;
using System.Collections.Generic;
using System.Drawing;

namespace Wingine.UI
{
    [Serializable]
    public abstract class IUIComponent : IComponent
    {
        [HideInInspector]
        public Canvas Surface { get { return surface; } set { surface = value; surface?.AddComponent(this); } }
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
            if (x.RenderOrder == 0 || y.RenderOrder == 0)
            {
                return 0;
            }

            // CompareTo() method
            return x.RenderOrder.CompareTo(y.RenderOrder);

        }
    }
}
