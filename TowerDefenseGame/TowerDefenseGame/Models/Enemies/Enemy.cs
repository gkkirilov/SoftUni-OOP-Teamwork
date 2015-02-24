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

    public abstract class Enemy : GameObject, IEnemy
    {
        private double speed;
        private double lifePoints;
        private int beaconCounter = 0;
        private int bounty;

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

        protected Enemy(double x, double y, int width, int height, double lifePoints, double speed, CroppedBitmap[][] enemySprites, int bounty)
            : base(x, y, width, height, Brushes.Transparent)
        {
            this.LifePoints = lifePoints + (Level * 50);
            this.Speed = speed;
            this.enemySprites = enemySprites;
            this.bounty = bounty;

            healthPointsBar.Maximum = lifePoints;
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

            if (EnemyController.EnemyBeacons.Length <= this.beaconCounter)
            {
                PlayerInterfaceController.PlayerLife -= 1;
                this.Exists = false;
                return;
            }
            else if (this.LifePoints <= 0) 
            {
                this.IsDying = true;
            }

            double lastPositionX = this.Coordinates.X;
            double lastPositionY = this.Coordinates.Y;

            GeometryUtils.HandleMovement(this.Coordinates, EnemyController.EnemyBeacons[beaconCounter], this.Speed - this.Debuff.SpeedEffect);

            ResolveState(lastPositionX, lastPositionY);
            ResolveMovementAnimation();

            if (EnemyController.EnemyBeacons[beaconCounter].IsInside(this))
            {
                beaconCounter++;
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
                PlayerInterfaceController.Money += this.bounty; 
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

        public static void Upgrade()
        {
            Level++;
        }
    }
}
