namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class FireTower : Tower
    {
        private const int TowerSpeed = 50;
        private const int TowerRange = 225;
        private const int TowerDamage = 30;
        public const int TowerPrice = 125;

        private static readonly ImageBrush TowerImage = SpritesManager.FireTower;

        private const ProjectileSelection ProjectileType = ProjectileSelection.FireProjectile;

        public FireTower(double x, double y)
            : base(
            x,
            y,
            Constants.FieldSegmentSize,
            Constants.FieldSegmentSize,
            TowerSpeed,
            TowerRange,
            TowerDamage,
            TowerImage,
            TowerPrice,
            ProjectileType)
        {
        }

        protected override void SetLevelBonus()
        {
            switch (this.Level)
            {
                case 1:
                    this.levelBonus +=12;
                    break;
                case 2:
                    this.levelBonus += 12;
                    break;
                case 3:
                    this.levelBonus += 12;
                    break;
                case 4:
                    this.levelBonus += 12;
                    break;
                case 5:
                    this.levelBonus += 12;
                    break;
                case 6:
                    this.levelBonus += 12;
                    break;
                case 7:
                    this.levelBonus += 12;
                    break;
                case 8:
                    this.levelBonus += 12;
                    break;
                case 9:
                    this.levelBonus += 12;
                    break;
                case 10:
                    this.levelBonus += 12;
                    break;
            }
        }
    }
}
