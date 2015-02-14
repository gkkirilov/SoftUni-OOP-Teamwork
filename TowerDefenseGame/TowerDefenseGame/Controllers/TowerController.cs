using System;
using System.Collections.Generic;
using System.Windows.Input;
using TowerDefenseGame.Core;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Models.Towers;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using TowerDefenseGame.Enumerations;


namespace TowerDefenseGame.Controllers
{
    static class TowerController
    {
        private static List<Tower> towers = new List<Tower>();
        private static int towerCount = 0;

        public static List<Tower> Towers
        {
            get
            {
                return TowerController.towers;
            }
        }

        public static void GenerateTower(double x, double y)
        {
            TowerController.towerCount++;

            switch (PlayerInterfaceController.TowerSelected)
            {
                case TowerType.Arrow:
                    TowerController.Towers.Add(new ArrowTower(x, y));
                    break;
                case TowerType.Fire:
                    TowerController.Towers.Add(new FireTower(x, y));
                    break;
                case TowerType.Slow:
                    TowerController.Towers.Add(new SlowTower(x, y));
                    break;
                case TowerType.Sniper:
                    TowerController.Towers.Add(new SniperTower(x, y));
                    break;
                default:
                    break;
            }
        }

        public static void Update()
        {
            for (int index = 0; index < TowerController.Towers.Count; index++)
            {
                TowerController.Towers[index].Update();
                if (!TowerController.Towers[index].Exists)
                {
                    TowerController.Towers.RemoveAt(index);
                    index--;
                }
            }

        }

        
        public static void Render()
        {
            foreach (var tower in TowerController.Towers)
            {
                AnimationController.Renderer.Render(tower);
            }
        }

        
    }
}
