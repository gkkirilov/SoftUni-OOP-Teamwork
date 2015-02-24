namespace TowerDefenseGame.Models
{
    using System.Windows.Media;
    using Enumerations;
    using Utilities;

    public class FieldSegment : GameObject
    {

        public FieldSegment(double x, double y)
            : base(x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, Brushes.Transparent)
        {
            this.Model.Stroke = Brushes.DarkBlue;
        }

        public FieldType FieldType { get; set; }

        public bool IsOccupied { get; set; }
    }
}
