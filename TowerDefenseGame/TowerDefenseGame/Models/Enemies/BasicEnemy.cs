using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Enemies
{
    public class BasicEnemy : Enemy
    {
        private const int LifePoints = 50;
        private const int Speed = 1;  
        public BasicEnemy(double x, double y) 
            : base(x, y, 50, 50, BasicEnemy.LifePoints, BasicEnemy.Speed, Brushes.Black)
        {

        }
    }
}
