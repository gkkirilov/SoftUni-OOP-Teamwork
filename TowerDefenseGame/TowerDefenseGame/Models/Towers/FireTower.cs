namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class FireTower : Tower
    {
        private const int Speed = 10;
        private const int Range = 400;

        public FireTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, FireTower.Speed, FireTower.Range, Brushes.Purple)
        {
        }
    }
}
