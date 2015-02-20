using TowerDefenseGame.Controllers;

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
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Resources;

    public abstract class Enemy : GameObject, IEnemy
    {
        private double speed;
        private double lifePoints;
        private int beaconCounter = 0;
        private int bounty;

        // Variables used for the animation
        private EnemyState currentState = EnemyState.Left;
        private const int DirectionMultiplierY = 65;
        private const int DirectionMultiplierX = 65;
        private int spriteFrameCounter = 5;
        private int frameCounter = 0;
        private int deathSpriteFrameCounter = 0;
        private bool isDying = false;
        private IDebuff debuff = new NullDebuff();

        protected Enemy(double x, double y, int width, int height, double lifePoints, double speed, BitmapImage enemySpriteSheet, int bounty)
            : base(x, y, width, height, Brushes.Transparent)
        {
            this.LifePoints = lifePoints;
            this.Speed = speed;
            this.EnemySpriteSheet = enemySpriteSheet;
            this.bounty = bounty;
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
                this.Model.Fill = new ImageBrush(SpritesManager.GoblinSprites[(int)this.currentState][this.spriteFrameCounter]);

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
