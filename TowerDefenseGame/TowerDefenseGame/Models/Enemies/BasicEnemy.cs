using System;

namespace TowerDefenseGame.Models.Enemies
{
    class BasicEnemy : Enemy
    {
        private const int LifePoints = 50;
        private const int Speed = 10;

        public BasicEnemy(int x, int y) : base(x, y, 50, 50, BasicEnemy.LifePoints, BasicEnemy.Speed)
        {

        }
    }
}
