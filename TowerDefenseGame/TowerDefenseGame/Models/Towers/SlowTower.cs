namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class SlowTower : Tower
    {
        private const int Speed = 50;
        private const int Range = 250;

        public SlowTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, SlowTower.Speed, SlowTower.Range, Brushes.DeepSkyBlue)
        {
        }
    }
}
