using System;
using System.Collections.Generic;
using System.Windows;

namespace Wingine.UI
{
    public enum RenderSpace
    {
        Screen,
        World,
    }

    [Serializable]
    public class Canvas : IComponent
    {
        List<IUIComponent> UI_Components = new List<IUIComponent>();

        internal void AddComponent(IUIComponent component) => UI_Components.Add(component);
        internal void RemoveComponent(IUIComponent component) => UI_Components.Remove(component);

        public List<IUIComponent> GetUIComponents() => UI_Components;

        public RenderSpace RenderSpace = RenderSpace.Screen;

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
            for (int i = 0; i < UI_Components.Count; i++)
            {
                if (!Runner.App.CurrentScene.GameObjects.Contains(UI_Components[i].GameObject)
                    ||
                    !UI_Components[i].GameObject.GetComponents().Contains(UI_Components[i]))
                {
                    UI_Components.Remove(UI_Components[i]);
                }
            }
        }
    }
}
