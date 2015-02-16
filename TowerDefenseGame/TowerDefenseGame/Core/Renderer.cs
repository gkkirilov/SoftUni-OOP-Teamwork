namespace TowerDefenseGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using TowerDefenseGame.Interfaces;
    using TowerDefenseGame.Models;

    public class Renderer : IRenderer
    {
        public Renderer(Canvas container)
        {
            this.Container = container;
        }

        private Canvas Container { get; set; }

        public void Render(object obj)
        {
            if (obj is IGameObject)
            {
                this.RenderObject(obj as IGameObject);
            }
        }

        public void Clear()
        {
            this.Container.Children.Clear();
        }

        public void RemoveModel(IGameObject gameObject)
        {
            this.Container.Children.Remove(gameObject.Model);
        }

        private void RenderObject(IGameObject gameObject)
        {
            Canvas.SetLeft(gameObject.Model, gameObject.Coordinates.X);
            Canvas.SetTop(gameObject.Model, gameObject.Coordinates.Y);

            if (!this.Container.Children.Contains(gameObject.Model))
            {
                this.Container.Children.Add(gameObject.Model);   
            }
        }
    }
}
