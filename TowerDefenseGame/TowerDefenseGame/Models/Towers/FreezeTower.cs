namespace TowerDefenseGame.Models.Towers
{
    using Enumerations;
    using Resources;
    using System.Windows.Media;
    using Utilities;

    public class FreezeTower : Tower
    {
        private const int TowerSpeed = 20;
        private const int TowerRange = 250;
        private const int TowerDamage = 5;
        public const int TowerPrice = 35;

        private static readonly ImageBrush TowerImage = SpritesManager.FreezeTower;
        private static readonly ImageBrush TowerProfileImage = SpritesManager.FreezeTower;

        private const ProjectileSelection ProjectileType = ProjectileSelection.FreezeProjectile;
    

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
                    this.levelBonus = 0;
                    break;
                case 2:
                    this.levelBonus = 0;
                    break;
                case 3:
                    this.levelBonus = 0;
                    break;
                case 4:
                    this.levelBonus = 0;
                    break;
                case 5:
                    this.levelBonus = 0;
                    break;
                case 6:
                    this.levelBonus = 0;
                    break;
                case 7:
                    this.levelBonus = 0;
                    break;
                case 8:
                    this.levelBonus = 0;
                    break;
                case 9:
                    this.levelBonus = 0;
                    break;
                case 10:
                    this.levelBonus = 0;
                    break;
            }
        }
    }
}
