namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class SniperTower : Tower
    {
        private const int TowerSpeed = 75;
        private const int TowerRange = 350;
        private const int TowerDamage = 70;
        public const int TowerPrice = 300;

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
                    this.levelBonus += 60;
                    break;
                case 3:
                    this.levelBonus += 90;
                    break;
                case 4:
                    this.levelBonus += 120;
                    break;
                case 5:
                    this.levelBonus += 150;
                    break;
                case 6:
                    this.levelBonus += 180;
                    break;
                case 7:
                    this.levelBonus += 210;
                    break;
                case 8:
                    this.levelBonus += 240;
                    break;
                case 9:
                    this.levelBonus += 270;
                    break;
                case 10:
                    this.levelBonus += 300;
                    break;
            }
        }
    }
}
