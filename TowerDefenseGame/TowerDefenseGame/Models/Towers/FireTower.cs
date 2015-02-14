using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TowerDefenseGame.Core;

namespace TowerDefenseGame.Models.Towers
{
    class FireTower : Tower
    {
        private const int Speed = 10;
        private const int Range = 400;

        public FireTower(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize,
                FireTower.Speed, FireTower.Range, Brushes.Purple)
        {

        }
    }
}
