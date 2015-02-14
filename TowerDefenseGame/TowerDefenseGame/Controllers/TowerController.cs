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

        public static void GenerateTower(int x, int y,string towerEffect)
        {
            TowerController.towerCount++;
            if (towerEffect == "ArrowTower")
            {
                TowerController.Towers.Add(new ArrowTower(x, y));
            }
                
            else if (towerEffect == "SlowTower")
            {
                TowerController.Towers.Add(new SlowTower(x, y));
            }
            else if (towerEffect == "SniperTower")
            {
                TowerController.Towers.Add(new SniperTower(x, y));
            }
            else if(towerEffect=="SplashTower")
                TowerController.Towers.Add(new SplashTower(x, y));
           
        }

        public static void Update()
        {
            TowerController.GenerateTower(6 * Constants.FieldSegmentSize, 7 * Constants.FieldSegmentSize,"ArrowTower");
            TowerController.GenerateTower(5 * Constants.FieldSegmentSize, 8 * Constants.FieldSegmentSize, "SlowTower"); 
            TowerController.GenerateTower(1 * Constants.FieldSegmentSize, 2 * Constants.FieldSegmentSize, "SniperTower");
            TowerController.GenerateTower(10 * Constants.FieldSegmentSize, 7 * Constants.FieldSegmentSize, "SplashTower");
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
