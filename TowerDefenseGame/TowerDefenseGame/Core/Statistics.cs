
using System.Windows;

namespace TowerDefenseGame.Core
{
    using System;
    using System.Windows.Controls;
    using TowerDefenseGame.Controllers;
    using System.Windows.Media;
    using System.Security.Cryptography.X509Certificates;

    class Statistics
    {
        public static TextBlock Money { get; set; }

        public static TextBlock PlayerLife { get; set; }

        public static TextBlock TowerInfo{ get; set; }
    
        static Statistics()
        {
            Money = new TextBlock();
            PlayerLife = new TextBlock();
            TowerInfo = new TextBlock();
        }
        public static void Render()
        {
            AnimationController.Renderer.DrawText(Money, 950, 9);
            AnimationController.Renderer.DrawText(PlayerLife, 1055, 9);
            AnimationController.Renderer.DrawText(TowerInfo, 1155, 500);
        }

        public static void SetTowerInfo(string text, Brush color)
        {
            TowerInfo.Foreground = color;
            TowerInfo.Text = text;
            TowerInfo.FontSize = 20;
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
            SetLife(PlayerInterfaceController.PlayerLife.ToString(),Brushes.Green);
            SetTowerInfo(PlayerInterfaceController.TowerInfo.ToString(),Brushes.Black);
        }
    }
}
