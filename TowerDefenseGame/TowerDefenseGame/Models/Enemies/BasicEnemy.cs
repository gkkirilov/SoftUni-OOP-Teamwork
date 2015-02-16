namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class BasicEnemy : Enemy
    {
        private const int LifePoints = 50;
        
        private const int Speed = 10;  

        public BasicEnemy(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, BasicEnemy.LifePoints, BasicEnemy.Speed, Brushes.Black)
        {
        }
    }
}
