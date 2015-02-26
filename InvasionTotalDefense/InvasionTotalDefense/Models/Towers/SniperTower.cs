namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class SniperTower : Tower
    {
        public const int TowerPrice = 300;
        private const int TowerSpeed = 75;
        private const int TowerRange = 350;
        private const int TowerDamage = 70;
        private const ProjectileSelection ProjectileType = ProjectileSelection.SniperProjectile;

        private static readonly ImageBrush TowerImage = SpritesManager.SniperTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.SniperTowerProfile;

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
                    this.LevelBonus += 20;
                    break;
                case 2:
                    this.LevelBonus += 20;
                    break;
                case 3:
                    this.LevelBonus += 20;
                    break;
                case 4:
                    this.LevelBonus += 25;
                    break;
                case 5:
                    this.LevelBonus += 25;
                    break;
                case 6:
                    this.LevelBonus += 30;
                    break;
                case 7:
                    this.LevelBonus += 40;
                    break;
                case 8:
                    this.LevelBonus += 40;
                    break;
                case 9:
                    this.LevelBonus += 40;
                    break;
                case 10:
                    this.LevelBonus += 50;
                    break;
            }
        }
    }
}
