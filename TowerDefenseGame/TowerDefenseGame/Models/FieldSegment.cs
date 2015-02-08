using System;
using System.Windows.Media;
using TowerDefenseGame.Core;
using TowerDefenseGame.Interfaces;

namespace TowerDefenseGame.Models
{
    class FieldSegment : GameObject, IFieldSegment
    {
        public FieldSegment(int x, int y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize)
        {
            this.Model.Fill = Brushes.AliceBlue;
            this.Model.Stroke = Brushes.DarkBlue;
        }
    }
}
