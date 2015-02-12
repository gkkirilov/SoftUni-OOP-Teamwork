using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TowerDefenseGame.Interfaces;
using TowerDefenseGame.Models.Enemies;
using Point = TowerDefenseGame.Geometry.Point;

namespace TowerDefenseGame.Models
{
    abstract class GameObject : IGameObject
    {
        private Point coordinates;
        private int width;
        private int height;
        private Rectangle model;

        protected GameObject(double x, double y, int width, int height)
        {
            this.Coordinates = new Point(x, y);
            this.Model = new Rectangle();
            this.Width = width;
            this.Height = height;

            this.Model.Height = height;
            this.Model.Width = width;

            Uri uri = new Uri(
            Directory.GetCurrentDirectory() +
            @"\skeleton.png", UriKind.Absolute);
            BitmapImage bmi = new BitmapImage(uri);
            CroppedBitmap cbm = new CroppedBitmap();


            cbm.BeginInit();
            cbm.Source = bmi;
            cbm.EndInit();
            cbm.SourceRect = new Int32Rect(100, 250, 100, 200);
            this.Model.Fill = new ImageBrush(cbm);
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

        public Rectangle Model
        {
            get 
            { 
                return this.model; 
            }
            set
            {
                this.model = value;
            }
        }
    }
}
