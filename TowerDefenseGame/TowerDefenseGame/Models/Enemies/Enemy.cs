namespace TowerDefenseGame.Models.Enemies
{
    using System;
    using System.Collections.Generic;
    using TowerDefenseGame.Enumerations;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Interfaces;
    using TowerDefenseGame.Models.Effects.Debuffs;

    public abstract class Enemy : GameObject, IEnemy
    {
        private double speed;
        private double lifePoints;
        private List<Point> beacons = new List<Point>();
        private IDebuff debuff = new NullDebuff();

        // Variables used for the animation
        private EnemyState currentState = EnemyState.Left;
        private const int DirectionMultiplierY = 65;
        private const int DirectionMultiplierX = 65;
        private int spriteFrameCounter = 6;
        private int frameCounter = 0;
        private int deathSpriteFrameCounter = 0;
        private bool isDying = false;

        protected Enemy(double x, double y, int width, int height, double lifePoints, double speed, BitmapImage enemySpriteSheet)
            : base(x, y, width, height, Brushes.Transparent)
        {
            this.LifePoints = lifePoints;
            this.Speed = speed;
            this.EnemySpriteSheet = enemySpriteSheet;
        }

        public List<Point> Beacons
        {
            get
            {
                return this.beacons;
            }

            private set
            {
                this.beacons = value;
            }
        }

        public double Speed
        {
            get
            {
                return this.speed;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The speed cannot be a negative number");
                }

                this.speed = value;
            }
        }

        public double LifePoints { get; private set; }

        private BitmapImage EnemySpriteSheet { get; set; }

        public IDebuff Debuff 
        {
            get
            {
                return this.debuff;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The value cannot be null");
                }
                this.debuff = value;
            }
        }

        public bool IsDying
        {
            get
            {
                return this.isDying;
            }

            private set
            {
                this.isDying = value;
            }
        }

        public override void Update()
        {
            ResolveDebuffState();

            this.LifePoints -= this.Debuff.LifePointsEffect;

            if (this.IsDying)
            {
                ResolveDeathAnimation();
                return;
            }

            if (this.Beacons.Count == 0)
            {
                // Handle Player Base life points reduction
                this.Exists = false;
                return;
            }
            else if (this.LifePoints <= 0) 
            {
                this.IsDying = true;
            }

            Point.HandleMovement(this.Coordinates, this.Beacons[0], this.Speed - this.Debuff.SpeedEffect);

            ResolveState();
            ResolveMovementAnimation();

            if (this.Beacons[0].IsInside(this))
            {
                this.Beacons.RemoveAt(0);
                this.Update();
            }  
        }

        public void SetBeacons(List<Point> newBeacons)
        {
            this.Beacons = newBeacons;
        }

        public void TakeDamage(int damage)
        {
            this.LifePoints -= damage;
        }

        private void ResolveDebuffState()
        {
            this.Debuff.Update();

            if (this.Debuff.HasElapsed)
            {
                this.Debuff = new NullDebuff();
            }
        }

        private void ResolveState()
        {
            if (isDying)
            {
                currentState = EnemyState.Dying;
            }
            else if (this.Beacons[0].X < Math.Round(this.Coordinates.X))
            {
                currentState = EnemyState.Left;
            }
            else if (this.Beacons[0].X > Math.Round(this.Coordinates.X))
            {
                currentState = EnemyState.Right;
            }

            else if (this.Beacons[0].Y < Math.Round(this.Coordinates.Y))
            {
                currentState = EnemyState.Up;
            }
            else if (this.Beacons[0].Y > Math.Round(this.Coordinates.Y))
            {
                currentState = EnemyState.Down;
            }
        }

        private void ResolveMovementAnimation()
        {
            frameCounter++;
            if (frameCounter >= 5 + (this.Debuff.SpeedEffect * 2))
            {
                frameCounter = 0;
                this.Model.Fill = new ImageBrush(new CroppedBitmap(this.EnemySpriteSheet,
                    new System.Windows.Int32Rect(DirectionMultiplierX * spriteFrameCounter,
                        DirectionMultiplierY * (int)currentState, 60, 57)));
                spriteFrameCounter--;
            }

            if (spriteFrameCounter <= 0)
            {
                spriteFrameCounter = 6;
            }
        }

        private void ResolveDeathAnimation()
        {
            if (deathSpriteFrameCounter >= 5)
            {
                this.Exists = false;
                return;
            }

            frameCounter++;
            if (frameCounter >= 8)
            {
                frameCounter = 0;

                this.Model.Fill = new ImageBrush(
                   new CroppedBitmap(this.EnemySpriteSheet,
                   new System.Windows.Int32Rect(
                       DirectionMultiplierX * deathSpriteFrameCounter,
                       DirectionMultiplierY * (int)currentState, 60, 57)));

                deathSpriteFrameCounter++;   
            }
        }
    }
}
