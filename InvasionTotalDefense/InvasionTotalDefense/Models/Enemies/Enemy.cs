namespace TowerDefenseGame.Models.Enemies
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Debuffs;
    using Enumerations;
    using Geometry;
    using Interfaces;
    using Utilities;

    public abstract class Enemy : GameObject, IEnemy
    {
        public static readonly Point[] EnemyBeacons = new Point[] 
        { 
            new Point(29 * Constants.FieldSegmentSize, 16 * Constants.FieldSegmentSize),
            new Point(2 * Constants.FieldSegmentSize, 16 * Constants.FieldSegmentSize),
            new Point(2 * Constants.FieldSegmentSize, 11 * Constants.FieldSegmentSize),
            new Point(28 * Constants.FieldSegmentSize, 11 * Constants.FieldSegmentSize),
            new Point(27 * Constants.FieldSegmentSize, 8 * Constants.FieldSegmentSize),
            new Point(2 * Constants.FieldSegmentSize, 8 * Constants.FieldSegmentSize),
            new Point(2 * Constants.FieldSegmentSize, 5 * Constants.FieldSegmentSize),
            new Point(28 * Constants.FieldSegmentSize, 5 * Constants.FieldSegmentSize),
            new Point(27 * Constants.FieldSegmentSize, 3 * Constants.FieldSegmentSize),
        };

        private static int level = 1;

        private double speed;
        private int beaconCounter = 0;

        // Variables used for the animation
        private EnemyState currentState = EnemyState.Left;
        private int spriteFrameCounter = 5;
        private int frameCounter = 0;
        private int deathSpriteFrameCounter = 0;
        private CroppedBitmap[][] enemySprites;
        private ProgressBar healthPointsBar = new ProgressBar();

        private bool isDying;
        private IDebuff debuff = new NullDebuff();

        protected Enemy(double x, double y, int width, int height, double lifePoints, double speed, CroppedBitmap[][] enemySprites, int bounty)
            : base(x, y, width, height, Brushes.Transparent)
        {
            this.LifePoints = lifePoints + ((lifePoints * 80 / 100) * level);
            this.Speed = speed;
            this.enemySprites = enemySprites;
            this.Bounty = bounty + (level * 2);

            this.InitializeHealthBar(width);
        }

        public double Speed
        {
            get
            {
                var result = this.speed - this.Debuff.SpeedEffect;

                return result < 1 ? 1 : result;
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

        public int Bounty
        {
            get;
            private set;
        }

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

        public ProgressBar HealthBar
        {
            get { return this.healthPointsBar; }
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

        public bool HasExited
        {
            get;
            private set;
        }

        public static void Upgrade()
        {
            level++;
        }

        public override void Update()
        {
            this.LifePoints -= this.Debuff.LifePointsEffect;

            this.healthPointsBar.Value = this.LifePoints;

            this.ResolveDebuffState();

            if (this.IsDying)
            {
                this.ResolveDeathAnimation();
                return;
            }

            if (EnemyBeacons.Length <= this.beaconCounter)
            {
                this.HasExited = true;
                return;
            }
            else if (this.LifePoints <= 0)
            {
                this.IsDying = true;
            }

            double lastPositionX = this.Coordinates.X;
            double lastPositionY = this.Coordinates.Y;

            GeometryUtils.HandleMovement(this.Coordinates, EnemyBeacons[this.beaconCounter], this.Speed);

            this.ResolveState(lastPositionX, lastPositionY);
            this.ResolveMovementAnimation();

            if (EnemyBeacons[this.beaconCounter].IsInside(this))
            {
                this.beaconCounter++;
                this.Update();
            }
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

        private void ResolveState(double lastPositionX, double lastPositionY)
        {
            if (this.isDying)
            {
                this.currentState = EnemyState.Dying;
            }
            else if (Math.Abs(lastPositionY - this.Coordinates.Y) < 1 && lastPositionX < this.Coordinates.X)
            {
                this.currentState = EnemyState.Right;
            }
            else if (Math.Abs(lastPositionY - this.Coordinates.Y) < 1 && lastPositionX > this.Coordinates.X)
            {
                this.currentState = EnemyState.Left;
            }
            else if (lastPositionY < this.Coordinates.Y)
            {
                this.currentState = EnemyState.Down;
            }
            else if (lastPositionY > this.Coordinates.Y)
            {
                this.currentState = EnemyState.Up;
            }
        }

        private void ResolveMovementAnimation()
        {
            this.frameCounter++;
            if (this.frameCounter >= 1 + (this.Debuff.SpeedEffect * 2))
            {
                this.frameCounter = 0;
                this.Model.Fill = new ImageBrush(this.enemySprites[(int)this.currentState][this.spriteFrameCounter]);

                this.spriteFrameCounter--;
            }

            if (this.spriteFrameCounter <= 0)
            {
                this.spriteFrameCounter = 5;
            }
        }

        private void ResolveDeathAnimation()
        {
            if (this.deathSpriteFrameCounter >= 5)
            {
                this.Exists = false;
                return;
            }

            this.frameCounter++;
            if (this.frameCounter >= 3)
            {
                this.frameCounter = 0;

                this.Model.Fill =
                    new ImageBrush(
                        this.enemySprites[(int)this.currentState][this.deathSpriteFrameCounter]);

                this.deathSpriteFrameCounter++;
            }
        }

        private void InitializeHealthBar(int width)
        {
            this.healthPointsBar.Maximum = this.LifePoints;
            this.healthPointsBar.Minimum = 0;
            this.healthPointsBar.Height = 5;
            this.healthPointsBar.Width = width;
            this.healthPointsBar.Background = Brushes.Red;
            this.healthPointsBar.Foreground = Brushes.Green;
            this.healthPointsBar.BeginAnimation(ProgressBar.ValueProperty, null);
        }
    }
}
