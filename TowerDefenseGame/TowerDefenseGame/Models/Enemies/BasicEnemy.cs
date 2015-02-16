namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class BasicEnemy : Enemy
    {
        private const double EnemyLifePoints = 50;
                      
        private const double EnemySpeed = 1;  

        public BasicEnemy(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, EnemyLifePoints, EnemySpeed, Brushes.Black)
        {
        }
    }
}
