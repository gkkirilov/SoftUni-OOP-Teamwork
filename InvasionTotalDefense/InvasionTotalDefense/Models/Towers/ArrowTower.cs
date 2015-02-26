namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class ArrowTower : Tower
    {
        public const int TowerPrice = 50;

        private const int TowerSpeed = 8;
        private const int TowerRange = 100;
        private const int TowerDamage = 5;
        private const ProjectileSelection ProjectileType = ProjectileSelection.ArrowProjectile;

        private static readonly ImageBrush TowerImage = SpritesManager.ArrowTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.ArrowTowerProfile;

        public ArrowTower(double x, double y)
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
                    this.LevelBonus += 3;
                    break;
                case 2:
                    this.LevelBonus += 4;
                    break;
                case 3:
                    this.LevelBonus += 5;
                    break;
                case 4:
                    this.LevelBonus += 6;
                    break;
                case 5:
                    this.LevelBonus += 7;
                    break;
                case 6:
                    this.LevelBonus += 8;
                    break;
                case 7:
                    this.LevelBonus += 9;
                    break;
                case 8:
                    this.LevelBonus += 10;
                    break;
                case 9:
                    this.LevelBonus += 11;
                    break;
                case 10:
                    this.LevelBonus += 12;
                    break;
            }
        }
    }
}
