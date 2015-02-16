namespace TowerDefenseGame.Models
{
    using System;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Interfaces;
    using TowerDefenseGame.Models.Enemies;

    public abstract class GameObject : IGameObject
    {
        private Point coordinates;
        private int width;
        private int height;
        private bool exists = true;
        private Rectangle model;

        protected GameObject(double x, double y, int width, int height, Brush fillType)
        {
            this.Coordinates = new Point(x, y);
            this.Model = new Rectangle();
            this.Width = width;
            this.Height = height;

            this.Model.Height = height;
            this.Model.Width = width;

            // Uri uri = new Uri(
            // Directory.GetCurrentDirectory() +
            // @"..\..\..\Models\skeleton.png", UriKind.Absolute);
            // 
            // BitmapImage bmi = new BitmapImage(uri);
            // CroppedBitmap cbm = new CroppedBitmap();
            // 
            // 
            // cbm.BeginInit();
            // cbm.Source = bmi;
            // cbm.EndInit();
            // cbm.SourceRect = new Int32Rect(100, 250, 100, 200);
            // this.Model.Fill = new ImageBrush(cbm);
            this.Model.Fill = fillType;
        }

        public Point Coordinates
        {
            get
            {
                return this.coordinates;
            }

            set
            {
                this.coordinates = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("The width cannot be negative");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The height cannot be negative.");
                }

                this.height = value;
            }
        }

        public bool Exists
        {
            get
            {
                return this.exists;
            }

            protected set
            {
                this.exists = value;
            }
        }

        public Rectangle Model
        {
            get 
            { 
                return this.model; 
            }

            private set
            {
                this.model = value;
            }
        }

        public bool Intersects(GameObject target)
        {
            if (this.Coordinates.X + this.Width > target.Coordinates.X && this.Coordinates.X < target.Coordinates.X + target.Width &&
            this.Coordinates.Y + this.Height > target.Coordinates.Y && this.Coordinates.Y < target.Coordinates.Y + target.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void Update()
        {
        }
    }
}
