namespace TowerDefenseGame.Core
{
    using System.Text;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using TowerDefenseGame.Controllers;
    using System.Windows.Media;
    using System.Security.Cryptography.X509Certificates;

    class Statistics
    {
        public static TextBlock Money { get; set; }

        public static TextBlock PlayerLife { get; set; }

        public static TextBlock TowerInfo { get; set; }

        public static TextBlock UpgradePrice { get; set; }

        public static TextBlock RemoveTower { get; set; }

        static Statistics()
        {
            Money = new TextBlock();
            PlayerLife = new TextBlock();
            TowerInfo = new TextBlock();
            UpgradePrice = new TextBlock();
            RemoveTower = new TextBlock();
        }


        public static void Render()
        {
            AnimationController.Renderer.DrawText(Money, 950, 9);
            AnimationController.Renderer.DrawText(PlayerLife, 1055, 9);
            AnimationController.Renderer.DrawText(TowerInfo, 1004, 412);
            AnimationController.Renderer.DrawText(UpgradePrice, 1034, 505);
            AnimationController.Renderer.DrawText(RemoveTower, 1034, 538);
        }
        public static void SetRemoveTower(string text, Brush color)
        {
            RemoveTower.Foreground = color;
            RemoveTower.Text = text;
            RemoveTower.FontSize = 17;
            RemoveTower.FontWeight = FontWeights.Bold;
        }

        public static void SetUpgradePrice(string text, Brush color)
        {
            UpgradePrice.Foreground = color;
            UpgradePrice.Text = text;
            UpgradePrice.FontSize = 17;
            UpgradePrice.FontWeight = FontWeights.Bold;
        }

        public static void SetTowerInfo(string text, Brush color)
        {
            TowerInfo.Foreground = color;
            TowerInfo.Text = text;
            TowerInfo.FontSize = 17;
        }

        public static void SetMoney(string text, Brush color)
        {
            Money.Foreground = color;
            Money.Text = text;
            Money.FontSize = 25;
        }

        public static void SetLife(string text, Brush color)
        {
            PlayerLife.Foreground = color;
            PlayerLife.Text = text;
            PlayerLife.FontSize = 25;
        }

        public static void Update()
        {
            SetMoney(PlayerInterfaceController.Money.ToString(), Brushes.Goldenrod);
            SetLife(PlayerInterfaceController.PlayerLife.ToString(), Brushes.Green);
            if (PlayerInterfaceController.TowerSelected != null)
            {
                StringBuilder info = new StringBuilder();
                info.Append("Level: ");
                info.Append(PlayerInterfaceController.TowerSelected.Level.ToString());
                info.Append("\nDamage: ");
                info.Append(PlayerInterfaceController.TowerSelected.Damage.ToString());
                info.Append("\nRange: ");
                info.Append(PlayerInterfaceController.TowerSelected.Range.ToString());
                SetTowerInfo(info.ToString(), Brushes.Black);
                SetUpgradePrice(PlayerInterfaceController.TowerSelected.Price.ToString(), Brushes.Black);
                SetRemoveTower((PlayerInterfaceController.TowerSelected.Price / 3).ToString(), Brushes.Black);
            }
        }
    }
}