using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace TowerDefenseGame.Resources
{
    using System;
    using System.Windows;

    public static class SpritesManager
    {
        private const int SpriteSheetRows = 5;
        private const int SpriteSheetCols = 7;

        private static readonly BitmapImage goblinSpriteSheet = new BitmapImage(
            new Uri(@"..\..\Resources\Images\EnemySpriteSheets\Goblin.png",
                UriKind.Relative));

        private static readonly BitmapImage skeletonSpriteSheet = new BitmapImage(
           new Uri(@"..\..\Resources\Images\EnemySpriteSheets\Skeleton.png",
               UriKind.Relative));

        private static readonly BitmapImage zombieSpriteSheet = new BitmapImage(
           new Uri(@"..\..\Resources\Images\EnemySpriteSheets\Zombie.png",
               UriKind.Relative));

        private static readonly BitmapImage DeathSpriteSheet = new BitmapImage(
           new Uri(@"..\..\Resources\Images\EnemySpriteSheets\GrimReaper.png",
               UriKind.Relative));


        public static readonly ImageBrush ArrowTower =
            new ImageBrush(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\Images\TowerImages\ArrowTower.png", UriKind.Relative)));

        public static readonly ImageBrush ArrowTowerProfile =
            new ImageBrush(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\Images\TowerImages\ArrowTowerProfile.png", UriKind.Relative)));

        public static readonly ImageBrush FireTower =
           new ImageBrush(
                   new BitmapImage(
                       new Uri(@"..\..\Resources\Images\TowerImages\FireTower.png", UriKind.Relative)));

        public static readonly ImageBrush FireTowerProfile =
            new ImageBrush(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\Images\TowerImages\FireTowerProfile.png", UriKind.Relative)));

        public static readonly ImageBrush FreezeTower =
        new ImageBrush(
                new BitmapImage(
                    new Uri(@"..\..\Resources\Images\TowerImages\FreezeTower.png", UriKind.Relative)));

        public static readonly ImageBrush FreezeTowerProfile =
            new ImageBrush(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\Images\TowerImages\FreezeTowerProfile.png", UriKind.Relative)));

        public static readonly ImageBrush SniperTower =
            new ImageBrush(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\Images\TowerImages\SniperTower.png", UriKind.Relative)));

        public static readonly ImageBrush SniperTowerProfile =
            new ImageBrush(
                    new BitmapImage(
                        new Uri(@"..\..\Resources\Images\TowerImages\SniperTowerProfile.png", UriKind.Relative)));

        public static readonly ImageBrush ArrowProjectile =
      new ImageBrush(
              new BitmapImage(
                  new Uri(@"..\..\Resources\Images\ProjectileImages\ArrowProjectile.png", UriKind.Relative)));

        public static readonly ImageBrush FireProjectile =
     new ImageBrush(
             new BitmapImage(
                 new Uri(@"..\..\Resources\Images\ProjectileImages\FireProjectile.png", UriKind.Relative)));

        public static readonly ImageBrush FreezeProjectile =
    new ImageBrush(
            new BitmapImage(
                new Uri(@"..\..\Resources\Images\ProjectileImages\FreezeProjectile.png", UriKind.Relative)));

        public static readonly ImageBrush SniperProjectile =
    new ImageBrush(
            new BitmapImage(
                new Uri(@"..\..\Resources\Images\ProjectileImages\SniperProjectile.png", UriKind.Relative)));

        public static readonly CroppedBitmap[][] GoblinSprites = new CroppedBitmap[5][];
        public static readonly CroppedBitmap[][] SkeletonSprites = new CroppedBitmap[5][];
        public static readonly CroppedBitmap[][] ZombieSprites = new CroppedBitmap[5][];
        public static readonly CroppedBitmap[][] GrimReaperSprites = new CroppedBitmap[5][];

        static SpritesManager()
        {
            InitializeSprites();
        }

        private static void InitializeSprites()
        {
            int directionMultiplierX = 65;
            int directionMultiplierY = 65;

            for (int row = 0; row < SpriteSheetRows; row++)
            {
                GoblinSprites[row] = new CroppedBitmap[SpriteSheetCols];
                SkeletonSprites[row] = new CroppedBitmap[SpriteSheetCols];
                ZombieSprites[row] = new CroppedBitmap[SpriteSheetCols];
                GrimReaperSprites[row] = new CroppedBitmap[SpriteSheetCols];

                for (int col = 0; col < SpriteSheetCols; col++)
                {
                    GoblinSprites[row][col] = new CroppedBitmap(
                        goblinSpriteSheet,
                        new Int32Rect(directionMultiplierX * col,
                        directionMultiplierY * row, 60, 57));

                    SkeletonSprites[row][col] = new CroppedBitmap(
                        skeletonSpriteSheet,
                        new Int32Rect(directionMultiplierX * col,
                        directionMultiplierY * row, 60, 57));

                    ZombieSprites[row][col] = new CroppedBitmap(
                        zombieSpriteSheet,
                        new Int32Rect(directionMultiplierX * col,
                        directionMultiplierY * row, 60, 57));

                    GrimReaperSprites[row][col] = new CroppedBitmap(
                       DeathSpriteSheet,
                       new Int32Rect(directionMultiplierX * col,
                       directionMultiplierY * row, 60, 57));
                    
                }
            }
        }
    }
}
