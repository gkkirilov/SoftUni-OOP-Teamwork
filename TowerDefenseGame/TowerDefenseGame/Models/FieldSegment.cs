using System;
using System.Windows.Media;
using TowerDefenseGame.Core;
using TowerDefenseGame.Interfaces;
using TowerDefenseGame.Models.Enemies;

namespace TowerDefenseGame.Models
{
    class FieldSegment : GameObject, IFieldSegment
    {
        public FieldSegment(int x, int y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize)
        {
            this.Model.Stroke = Brushes.DarkBlue;
        }
    }
}
