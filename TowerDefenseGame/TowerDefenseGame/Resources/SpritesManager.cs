using System.Windows.Media.Imaging;
namespace TowerDefenseGame.Resources
{
    using System;
    using System.Windows;

    public static class SpritesManager
    {
        private const int SpriteSheetRows = 5;
        private const int SpriteSheetCols = 7;

        private static BitmapImage goblinSpriteSheet = new BitmapImage(
            new Uri(@"..\..\Resources\goblinsword.png",
                UriKind.Relative));

        public static readonly CroppedBitmap[][] GoblinSprites = new CroppedBitmap[5][];

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

                for (int col = 0; col < SpriteSheetCols; col++)
                {
                    GoblinSprites[row][col] = new CroppedBitmap(
                        goblinSpriteSheet,
                        new Int32Rect(directionMultiplierX * col,
                        directionMultiplierY * row, 60, 57));
                }
            }
        }
    }
}
