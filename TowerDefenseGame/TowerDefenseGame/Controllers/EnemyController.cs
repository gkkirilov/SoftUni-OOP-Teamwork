namespace TowerDefenseGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Models.Enemies;

    public static class EnemyController
    {
        private static List<IEnemy> enemies = new List<IEnemy>();
        private static List<Point> enemyBeacons = new List<Point>();
        private static int waveEnemiesCount = 0;
        private static bool isGenerating = false;
        private static int frameCount = 0;

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
            EnemyController.Enemies.Add(new BasicEnemy(x, y)); // TODO: Generate enemies based on type
        }

        public static void Update() 
        {
            for (int index = 0; index < EnemyController.Enemies.Count; index++)
            {
                EnemyController.Enemies[index].Update();

                if (!EnemyController.Enemies[index].Exists)
                {
                    AnimationController.Renderer.RemoveModel(EnemyController.Enemies[index]);
                    Enemies.RemoveAt(index);
                    index--;
                }
            }

            if (!isGenerating && frameCount >= Constants.WaveDelay)
            {
                //Timers.TimeToWave.Stop();
                //Timers.TimeToWave.Start();
                isGenerating = true;
            }

            if (isGenerating && frameCount >= Constants.EnemyGenerationDelay)
            {
                frameCount = 0;
                GenerateEnemy(
                    Constants.EnemyStartCol * Constants.FieldSegmentSize,
                    Constants.EnemyStartRow * Constants.FieldSegmentSize); 
            }

            frameCount++;

            if (EnemyController.WaveEnemiesCount >= Constants.WaveEnemiesMaxCount)
            {
                EnemyController.WaveEnemiesCount = 0;
                isGenerating = false;
            }
        }

        public static void Render()
        {
            foreach (var enemy in EnemyController.Enemies)
            {
                AnimationController.Renderer.Render(enemy);
            }
        }
    }
}
