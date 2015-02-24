namespace TowerDefenseGame.Core
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Interfaces;
    using System.Windows.Shapes;
    using Utilities;

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

        public void DrawText(TextBlock text,int x, int y)
        {
            Canvas.SetLeft(text, x);
            Canvas.SetTop(text, y);

            if (!this.Container.Children.Contains(text))
            {
                this.Container.Children.Add(text);
            }
        }

        public void RenderHealthBar(IEnemy creature)
        {
            Canvas.SetLeft(creature.HealthBar, creature.Coordinates.X);
            Canvas.SetTop(creature.HealthBar, creature.Coordinates.Y - 5);

            if (!this.Container.Children.Contains(creature.HealthBar))
            {
                this.Container.Children.Add(creature.HealthBar);
            }
        }

        public void RemoveHealthBar(IEnemy creature)
        {
            this.Container.Children.Remove(creature.HealthBar);
        }

        public void RenderGameOver()
        {
            Rectangle gameOverRectangle = new Rectangle();
            gameOverRectangle.Fill = new ImageBrush(new BitmapImage(
           new Uri(@"..\..\Resources\Images\GameOver.png",
               UriKind.Relative)));
            gameOverRectangle.Width = 500;
            gameOverRectangle.Height = 450;
            gameOverRectangle.Stroke = Brushes.DarkRed;
            gameOverRectangle.StrokeThickness = 5;

            Canvas.SetTop(gameOverRectangle, 100);
            Canvas.SetLeft(gameOverRectangle, 200);
            this.Container.IsHitTestVisible = false;
            this.Container.Children.Add(gameOverRectangle);
        }
    }
}
