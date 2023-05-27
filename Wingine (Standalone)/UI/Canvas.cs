using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wingine.UI
{
    [Serializable]
    public class Canvas : IComponent
    {
        List<IUIComponent> UI_Components = new List<IUIComponent>();

        internal void AddComponent(IUIComponent component) => UI_Components.Add(component);
        internal void RemoveComponent(IUIComponent component) => UI_Components.Remove(component);

        public List<IUIComponent> GetUIComponents() => UI_Components;

        //public Color BackgroundTint = Color.Transparent;
        public Action Reset { get; set; } = () =>
        {
            MessageBox.Show("Reset!");
        };


        public override void Begin()
        {

        }

        public override void Tick()
        {

        }
    }
}
