namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class FireTower : Tower
    {
        public const int TowerPrice = 125;
        private const int TowerSpeed = 50;
        private const int TowerRange = 150;
        private const int TowerDamage = 20;
        private const ProjectileSelection ProjectileType = ProjectileSelection.FireProjectile;

        private static readonly ImageBrush TowerImage = SpritesManager.FireTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.FireTowerProfile;

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
                    this.LevelBonus += 7;
                    break;
                case 2:
                    this.LevelBonus += 9;
                    break;
                case 3:
                    this.LevelBonus += 11;
                    break;
                case 4:
                    this.LevelBonus += 13;
                    break;
                case 5:
                    this.LevelBonus += 15;
                    break;
                case 6:
                    this.LevelBonus += 17;
                    break;
                case 7:
                    this.LevelBonus += 19;
                    break;
                case 8:
                    this.LevelBonus += 21;
                    break;
                case 9:
                    this.LevelBonus += 23;
                    break;
                case 10:
                    this.LevelBonus += 25;
                    break;
            }
        }
    }
}
