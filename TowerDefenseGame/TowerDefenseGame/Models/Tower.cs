using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Interfaces;


namespace TowerDefenseGame.Models.Towers
{
    abstract class Tower : GameObject
    {
        private int towerSpeed;
        private int towerRadius;
        private string towerEffect;

        protected Tower(int x, int y, int width, int height, int TowerSpeed,int TowerRadius,string TowerEffect, Brush fillBrush)
            : base(x, y, width, height, fillBrush)
        {
            this.towerSpeed = TowerSpeed;
            this.towerRadius = TowerRadius;
            this.towerEffect = TowerEffect;
        }

        public int TowerSpeed
        {
            get
            {
                return this.towerSpeed;
            }
            set
            {
                this.towerSpeed = value;
            }
        }

        public int TowerRadius
        {
            get
            {
                return this.towerRadius;
            }
            set
            {
                this.towerRadius = value;
            }
        }

        public string TowerEffect
        {
            get
            {
                return this.towerEffect;
            }
            set
            {
                this.towerEffect = value;
            }
        }


    }
}