using System;
using System.Collections.Generic;
using TowerDefenseGame.Models.Enemies;
using TowerDefenseGame.Core;
using System.Windows.Shapes;

namespace TowerDefenseGame.Core
{
    static class Engine
    {
        private static List<Enemy> enemies = new List<Enemy>();
        private static List<Rectangle> enemyBeacons = new List<Rectangle>();
        private static Rectangle[][] gameField = new Rectangle[Constants.FieldRows][];

        public static List<Enemy> Enemies 
        {
            get 
            {
                return Engine.enemies;
            }
        }

        public static Rectangle[][] GameField
        {
            get
            {
                return Engine.gameField;
            }
        }

        public static void GenerateEnemy(int x, int y)
        {
            Engine.Enemies.Add(new BasicEnemy(x, y));
        }

        public static void Update()
        {
            int exitCode = 0;
            foreach (var enemy in enemies)
            {
                exitCode = enemy.Update();
            }

            if (exitCode == 1)
            {
                enemies.RemoveAt(0);
            }

        }
    }
}
