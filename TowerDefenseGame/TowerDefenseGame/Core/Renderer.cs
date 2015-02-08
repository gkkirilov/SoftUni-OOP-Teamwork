using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Animations.AnimationInterfaces;
using TowerDefenseGame.Models;
using TowerDefenseGame.Interfaces;

namespace TowerDefenseGame.Core
{
    class Renderer : IRenderer
    {
        private readonly Brush BallFillColor = Brushes.AliceBlue;
        private readonly Brush BallStrokeColor = Brushes.DarkBlue;

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
