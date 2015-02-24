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
        public static TextBlock Money { get; set; }

        public static TextBlock PlayerLife { get; set; }

        public static TextBlock TowerStats { get; set; }

        public static TextBlock UpgradePrice { get; set; }

        public static TextBlock RemovePrice { get; set; }

        public static TextBlock TowerInformation { get; set; }

        static Statistics()
        {
            Money = new TextBlock();
            PlayerLife = new TextBlock();
            TowerStats = new TextBlock();
            UpgradePrice = new TextBlock();
            RemovePrice = new TextBlock();
            TowerInformation = new TextBlock();
        }

        public static void Render()
        {
            AnimationController.Renderer.DrawText(Money, 950, 9);
            AnimationController.Renderer.DrawText(PlayerLife, 1055, 9);
            AnimationController.Renderer.DrawText(TowerStats, 1004, 415);
            AnimationController.Renderer.DrawText(UpgradePrice, 1034, 503);
            AnimationController.Renderer.DrawText(RemovePrice, 1034, 540);
            AnimationController.Renderer.DrawText(TowerInformation, 834, 640);
        }

        public static void SetTowerInformation(string text, Brush color)
        {
            TowerInformation.Foreground = color;
            TowerInformation.Text = text;
            TowerInformation.FontSize = 17;
        }

        public static void SetRemovePrice(string text, Brush color)
        {
            RemovePrice.Foreground = color;
            RemovePrice.Text = text;
            RemovePrice.FontSize = 17;
            RemovePrice.FontWeight = FontWeights.Bold;
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
            TowerStats.Foreground = color;
            TowerStats.Text = text;
            TowerStats.FontSize = 17;
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
                SetRemovePrice(((PlayerInterfaceController.TowerSelected.Price) / 3).ToString(), Brushes.Black);
            }

            if (PlayerInterfaceController.TowerTypeSelected != null)
            {
                switch (PlayerInterfaceController.TowerTypeSelected)
                {
                    case TowerType.Arrow: SetTowerInformation(Constants.ArrowTowerInformation.ToString(), Brushes.Black);
                        break;
                    case TowerType.Fire: SetTowerInformation(Constants.FireTowerInformation.ToString(), Brushes.Black);
                        break;
                    case TowerType.Freeze: SetTowerInformation(Constants.FreezeTowerInformation.ToString(), Brushes.Black);
                        break;
                    case TowerType.Sniper: SetTowerInformation(Constants.SniperTowerInformation.ToString(), Brushes.Black);
                        break;
                }
            }
        }
    }
}