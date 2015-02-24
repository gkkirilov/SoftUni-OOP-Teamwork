namespace TowerDefenseGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Geometry;
    using Models.Enemies;
    using Utilities;

    public static class EnemyController
    {
        private static List<IEnemy> enemies = new List<IEnemy>();
        private static int waveEnemiesCount = 0;
        private static int waveCount = 0;
        private static int enemyTypeCounter = -1;

        public static readonly Point[] EnemyBeacons = new Point[] 
            { 
                new Point(2 * Constants.FieldSegmentSize, 16 * Constants.FieldSegmentSize),
                new Point(2 * Constants.FieldSegmentSize, 11 * Constants.FieldSegmentSize),
                new Point(28 * Constants.FieldSegmentSize, 11 * Constants.FieldSegmentSize),
                new Point(27 * Constants.FieldSegmentSize, 8 * Constants.FieldSegmentSize),
                new Point(2 * Constants.FieldSegmentSize, 8 * Constants.FieldSegmentSize),
                new Point(2 * Constants.FieldSegmentSize, 5 * Constants.FieldSegmentSize),
                new Point(28 * Constants.FieldSegmentSize, 5 * Constants.FieldSegmentSize),
                new Point(27 * Constants.FieldSegmentSize, 3 * Constants.FieldSegmentSize),
            };

        public static List<IEnemy> Enemies
        {
            get
            {
                return EnemyController.enemies;
            }
        }

        public static int WaveCount
        {
            get
            {
                return waveCount;
            }

            set
            {
                if (waveCount < 0)
                {
                    throw new ArgumentException("The count of the wave cannot be negative");
                }

                waveCount = value;
            }
        }

        public static int EnemyTypeCounter 
        {
            get
            {
                return enemyTypeCounter;
            }
            set
            {
                if (enemyTypeCounter < 0 || enemyTypeCounter > 3)
                {
                    enemyTypeCounter = 0;
                    return;
                }
                enemyTypeCounter = value;
            }
        }

        public static int WaveEnemiesCount
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

        public static void Update() 
        {
            for (int index = 0; index < EnemyController.Enemies.Count; index++)
            {
                EnemyController.Enemies[index].Update();

                if (!EnemyController.Enemies[index].Exists)
                {
                    AnimationController.Renderer.RemoveHealthBar(EnemyController.Enemies[index]);
                    AnimationController.Renderer.RemoveModel(EnemyController.Enemies[index]);
                    Enemies.RemoveAt(index);
                    index--;
                    Statistics.KilledEnemiesCounter++;
                }
            }
        }

        public static void GenerateEnemy(int x, int y)
        {
            EnemyController.WaveEnemiesCount++;
            switch (enemyTypeCounter)
            {
                case 0:
                    EnemyController.Enemies.Add(new Skeleton(x, y));
                    break;
                case 1:
                    EnemyController.Enemies.Add(new Zombie(x, y));
                    break;
                case 2:
                    EnemyController.Enemies.Add(new Goblin(x, y));
                    break;
                case 3:
                    EnemyController.Enemies.Add(new GrimReaper(x, y));
                    break;
                default:
                    enemyTypeCounter = 0;
                    EnemyController.Enemies.Add(new Skeleton(x, y));
                    break;
            }
        }

        public static void Render()
        {
            foreach (var enemy in EnemyController.Enemies)
            {
                AnimationController.Renderer.Render(enemy);
                AnimationController.Renderer.RenderHealthBar(enemy);
            }
        }
    }
}
