using TowerDefenseGame.Enumerations;
using TowerDefenseGame.Models.Towers;

namespace TowerDefenseGame.Utilities
{
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using Controllers;
    using System.Windows.Media;

    class Statistics
    {
        private static TextBlock money = new TextBlock();

        private static TextBlock playerLife = new TextBlock();

        private static TextBlock towerStats = new TextBlock();

        private static TextBlock upgradePrice = new TextBlock();

        private static TextBlock removePrice = new TextBlock();

        private static TextBlock towerInformation = new TextBlock();

        private static TextBlock waveCounter = new TextBlock();

        private static TextBlock killedEnemies = new TextBlock();

        private static int KilledEnemiesCounter = 0;

        static Statistics()
        {
            killedEnemies.Foreground = Brushes.Black;
            killedEnemies.FontSize = 25;

            waveCounter.Foreground = Brushes.Black;
            waveCounter.FontSize = 25;

            upgradePrice.FontSize = 17;
            upgradePrice.FontWeight = FontWeights.Bold;
            towerInformation.Foreground = Brushes.DarkGoldenrod;
            towerInformation.FontWeight = FontWeights.Bold;
            towerInformation.FontSize = 17;

            removePrice.Foreground = Brushes.Green;
            removePrice.FontSize = 17;
            removePrice.FontWeight = FontWeights.Bold;

            upgradePrice.Foreground = Brushes.Red;

            towerStats.Foreground = Brushes.Black;
            towerStats.FontSize = 17;

            money.Foreground = Brushes.Goldenrod;
            money.FontSize = 25;

            playerLife.Foreground = Brushes.Green;
            playerLife.FontSize = 25;
        }

        public static void Render()
        {
            AnimationController.Renderer.DrawText(money, 950, 9);
            AnimationController.Renderer.DrawText(playerLife, 1055, 9);
            AnimationController.Renderer.DrawText(towerStats, 1004, 415);
            AnimationController.Renderer.DrawText(upgradePrice, 1034, 503);
            AnimationController.Renderer.DrawText(removePrice, 1034, 540);
            AnimationController.Renderer.DrawText(towerInformation, 544, 640);
            AnimationController.Renderer.DrawText(waveCounter, 948, 52);
            AnimationController.Renderer.DrawText(killedEnemies, 1055, 52);
        }
        public static void SetKilledEnemies()
        {
            killedEnemies.Text = KilledEnemiesCounter.ToString();
        }

        public static void SetWaveCounter(string text)
        {
            waveCounter.Text = text;
        }

        public static void SetTowerInformation(string text)
        {
            towerInformation.Text = text;
        }

        public static void SetRemovePrice(string text)
        {
            removePrice.Text = text;
        }

        public static void SetUpgradePrice(string text)
        {
            upgradePrice.Text = text;
        }

        public static void SetTowerInfo(string text)
        {
            towerStats.Text = text;
        }

        public static void SetMoney(string text)
        {
            money.Text = text;
        }

        public static void SetLife(string text)
        {
            playerLife.Text = text;
        }

        public static void IncrementKilledEnemies()
        {
            KilledEnemiesCounter++;
        }
    }
}