namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class SniperTower : Tower
    {
        private const int TowerSpeed = 35;
        private const int TowerRange = 300;
        private const int TowerDamage = 70;
        public const int TowerPrice = 400;

        private static readonly ImageBrush TowerImage = SpritesManager.SniperTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.SniperTower;

        private const ProjectileSelection ProjectileType = ProjectileSelection.SniperProjectile;

        public SniperTower(double x, double y)
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
                    this.levelBonus += 30;
                    break;
                case 2:
                    this.levelBonus += 30;
                    break;
                case 3:
                    this.levelBonus += 30;
                    break;
                case 4:
                    this.levelBonus += 30;
                    break;
                case 5:
                    this.levelBonus += 30;
                    break;
                case 6:
                    this.levelBonus += 30;
                    break;
                case 7:
                    this.levelBonus += 30;
                    break;
                case 8:
                    this.levelBonus += 30;
                    break;
                case 9:
                    this.levelBonus += 30;
                    break;
                case 10:
                    this.levelBonus += 30;
                    break;
            }
        }
    }
}
