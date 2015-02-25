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
        private const int TowerDamage = 20;
        public const int TowerPrice = 125;

        private static readonly ImageBrush TowerImage = SpritesManager.FireTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.FireTowerProfile;

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
                    this.levelBonus +=7;
                    break;
                case 2:
                    this.levelBonus += 9;
                    break;
                case 3:
                    this.levelBonus += 11;
                    break;
                case 4:
                    this.levelBonus += 13;
                    break;
                case 5:
                    this.levelBonus += 15;
                    break;
                case 6:
                    this.levelBonus += 17;
                    break;
                case 7:
                    this.levelBonus += 19;
                    break;
                case 8:
                    this.levelBonus += 21;
                    break;
                case 9:
                    this.levelBonus += 23;
                    break;
                case 10:
                    this.levelBonus += 25;
                    break;
            }
        }
    }
}
