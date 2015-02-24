namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media.Imaging;
    using Resources;
    using Utilities;

    public class Zombie : Enemy
    {
        private const int EnemyLifePoints = 120;
        private const int EnemySpeed = 3;
        private const int Bounty = 20;


        private static readonly CroppedBitmap[][] EnemySprites = SpritesManager.ZombieSprites;

        public Zombie(double x, double y)
            : base(
                x,
                y,
                Constants.FieldSegmentSize,
                Constants.FieldSegmentSize,
                EnemyLifePoints,
                EnemySpeed,
                EnemySprites,
                Bounty)
        {
        }
    }
}
