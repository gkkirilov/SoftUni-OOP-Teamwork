namespace TowerDefenseGame.Models.Towers
{
    using System.Windows.Media;
    using Enumerations;
    using Resources;
    using Utilities;

    public class FreezeTower : Tower
    {
        public const int TowerPrice = 125;
        private const int TowerSpeed = 50;
        private const int TowerRange = 150;
        private const int TowerDamage = 15;
        private const ProjectileSelection ProjectileType = ProjectileSelection.FreezeProjectile;

        private static readonly ImageBrush TowerImage = SpritesManager.FreezeTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.FreezeTowerProfile;

        public FreezeTower(double x, double y)
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
                    this.LevelBonus += 8;
                    break;
                case 2:
                    this.LevelBonus += 8;
                    break;
                case 3:
                    this.LevelBonus += 8;
                    break;
                case 4:
                    this.LevelBonus += 8;
                    break;
                case 5:
                    this.LevelBonus += 8;
                    break;
                case 6:
                    this.LevelBonus += 8;
                    break;
                case 7:
                    this.LevelBonus += 8;
                    break;
                case 8:
                    this.LevelBonus += 8;
                    break;
                case 9:
                    this.LevelBonus += 8;
                    break;
                case 10:
                    this.LevelBonus += 8;
                    break;
            }
        }
    }
}
