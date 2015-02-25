namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class FireTower : Tower
    {
        private const int TowerSpeed = 50;
        private const int TowerRange = 150;
        private const int TowerDamage = 25;
        public const int TowerPrice = 125;

        private static readonly ImageBrush TowerImage = SpritesManager.FireTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.FireTower;

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
            TowerProfileImage,
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
                    this.levelBonus += 19;
                    break;
                case 3:
                    this.levelBonus += 29;
                    break;
                case 4:
                    this.levelBonus += 40;
                    break;
                case 5:
                    this.levelBonus += 52;
                    break;
                case 6:
                    this.levelBonus += 62;
                    break;
                case 7:
                    this.levelBonus += 72;
                    break;
                case 8:
                    this.levelBonus += 82;
                    break;
                case 9:
                    this.levelBonus += 92;
                    break;
                case 10:
                    this.levelBonus += 12;
                    break;
            }
        }
    }
}
