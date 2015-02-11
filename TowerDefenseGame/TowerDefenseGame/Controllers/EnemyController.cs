using System;
using System.Collections.Generic;
using TowerDefenseGame.Core;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Models.Enemies;

namespace TowerDefenseGame.Controllers
{
    static class EnemyController
    {
        private static List<Enemy> enemies = new List<Enemy>();
        private static List<Point> enemyBeacons = new List<Point>();
        private static int waveEnemiesCount = 0;

        public static List<Enemy> Enemies
        {
            get
            {
                return EnemyController.enemies;
            }
        }

        private static int WaveEnemiesCount
        {
            get
            {
                return EnemyController.waveEnemiesCount;
            }
            set
            {
                EnemyController.waveEnemiesCount = value;
            }
        }

        public static void GenerateEnemy(int x, int y)
        {
            EnemyController.WaveEnemiesCount++;
            EnemyController.Enemies.Add(new BasicEnemy(x, y));
            EnemyController.Enemies[EnemyController.Enemies.Count - 1].SetBeacons(EnemyController.GetEnemyBeacons());
        }

        public static void Update() 
        {
            bool hasExited = false;
            foreach (var enemy in EnemyController.Enemies)
            {
                bool exitStatus = enemy.Update();
                if (exitStatus == true)
                {
                    hasExited = true;
                }
            }

            if (hasExited)
            {
                AnimationController.Renderer.RemoveModel(EnemyController.Enemies[0]);
                EnemyController.Enemies.RemoveAt(0);
            }

            if (EnemyController.WaveEnemiesCount >= Constants.WaveEnemiesMaxCount)
            {
                Timers.EnemyGeneratorTimer.Stop();
                EnemyController.WaveEnemiesCount = 0;
                EnemyController.GenerateNextWave();
            }
        }

        public static void Render()
        {
            foreach (var enemy in EnemyController.Enemies)
            {
                AnimationController.Renderer.Render(enemy);
            }
        }

        public static void GenerateNextWave()
        {
            Timers.WaveDelayTimer.Start();
        }

        private static List<Point> GetEnemyBeacons()
        {
            List<Point> beacons = new List<Point> 
            { 
                new Point(2 * Constants.FieldSegmentSize, 10 * Constants.FieldSegmentSize),
                new Point(2 * Constants.FieldSegmentSize, 1 * Constants.FieldSegmentSize),
                new Point(7 * Constants.FieldSegmentSize, 1 * Constants.FieldSegmentSize)
            };

            return beacons;
        }
    }
}
