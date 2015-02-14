using System;
using System.Windows.Media;
using TowerDefenseGame.Core;
using TowerDefenseGame.Enumerations;
using TowerDefenseGame.Interfaces;
using TowerDefenseGame.Models.Enemies;

namespace TowerDefenseGame.Models
{
    public class FieldSegment : GameObject, IFieldSegment
    {
        private FieldType fieldType;

        public FieldSegment(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, Brushes.AliceBlue)
        {
            this.Model.Stroke = Brushes.DarkBlue;
        }

        public FieldType FieldType
        {
            get
            {
                return this.fieldType;
            }
            set
            {
                this.fieldType = value;
            }
        }
    }
}
