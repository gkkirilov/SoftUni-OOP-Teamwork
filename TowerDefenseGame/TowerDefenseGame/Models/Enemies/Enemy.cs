namespace TowerDefenseGame.Models.Enemies
{
    using System;
    using Enumerations;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Geometry;
    using Interfaces;
    using Controllers;
    using System.Windows.Controls;
    using Debuffs;
    using Utilities;

    public abstract class Enemy : GameObject, IEnemy
    {
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

        private static int Level = 1;

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

        protected Enemy(double x, double y, int width, int height, double lifePoints, double speed, CroppedBitmap[][] enemySprites, int bounty)
            : base(x, y, width, height, Brushes.Transparent)
        {
            this.LifePoints = lifePoints + (lifePoints * 70 / 100) * Level;
            this.Speed = speed;
            this.enemySprites = enemySprites;
            this.Bounty = bounty + (bounty * 20 / 100) * Level;

            healthPointsBar.Maximum = this.LifePoints;
            healthPointsBar.Minimum = 0;
            healthPointsBar.Height = 5;
            healthPointsBar.Width = width;
            healthPointsBar.Background = Brushes.Red;
            healthPointsBar.Foreground = Brushes.Green;
            healthPointsBar.BeginAnimation(ProgressBar.ValueProperty, null);
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

        public override void Update()
        {
            this.LifePoints -= this.Debuff.LifePointsEffect;

            healthPointsBar.Value = this.LifePoints;
            ResolveDebuffState();

            if (this.IsDying)
            {
                ResolveDeathAnimation();
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

            GeometryUtils.HandleMovement(this.Coordinates, EnemyBeacons[beaconCounter], this.Speed);

            ResolveState(lastPositionX, lastPositionY);
            ResolveMovementAnimation();

            if (EnemyBeacons[beaconCounter].IsInside(this))
            {
                beaconCounter++;
                this.Update();
            }
        }

        public void TakeDamage(int damage)
        {
            this.LifePoints -= damage;
        }

        public static void Upgrade()
        {
            Level++;
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
            if (isDying)
            {
                currentState = EnemyState.Dying;
            }
            else if (Math.Abs(lastPositionY - this.Coordinates.Y) < 1 && lastPositionX < this.Coordinates.X)
            {
                currentState = EnemyState.Right;
            }
            else if (Math.Abs(lastPositionY - this.Coordinates.Y) < 1 && lastPositionX > this.Coordinates.X)
            {
                currentState = EnemyState.Left;
            }

            else if (lastPositionY < this.Coordinates.Y)
            {
                currentState = EnemyState.Down;
            }
            else if (lastPositionY > this.Coordinates.Y)
            {
                currentState = EnemyState.Up;
            }
        }

        private void ResolveMovementAnimation()
        {
            frameCounter++;
            if (frameCounter >= 1 + (this.Debuff.SpeedEffect * 2))
            {
                frameCounter = 0;
                this.Model.Fill = new ImageBrush(this.enemySprites[(int)this.currentState][this.spriteFrameCounter]);

                spriteFrameCounter--;
            }

            if (spriteFrameCounter <= 0)
            {
                spriteFrameCounter = 5;
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
            if (frameCounter >= 3)
            {
                frameCounter = 0;

                this.Model.Fill =
                    new ImageBrush(
                        this.enemySprites
                            [(int)currentState]
                            [deathSpriteFrameCounter]);

                deathSpriteFrameCounter++;
            }
        }
    }
}
