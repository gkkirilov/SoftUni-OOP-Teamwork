namespace TowerDefenseGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Interfaces;
    using TowerDefenseGame.Models.Enemies;

    public static class EnemyController
    {
        private static List<Enemy> enemies = new List<Enemy>();
        private static List<Point> enemyBeacons = new List<Point>();
        private static int waveEnemiesCount = 0;
        private static bool isGenerating = false;
        private static int frameCount = 0;

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
            EnemyController.Enemies.Add(new BasicEnemy(x, y)); // TODO: Generate enemies based on type
            EnemyController.Enemies[EnemyController.Enemies.Count - 1].SetBeacons(EnemyController.GetEnemyBeacons());
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

        private static List<Point> GetEnemyBeacons()
        {
            List<Point> beacons = new List<Point> 
            { 
                new Point(2 * Constants.FieldSegmentSize, 10 * Constants.FieldSegmentSize),
                new Point(2 * Constants.FieldSegmentSize, 1 * Constants.FieldSegmentSize),
                new Point(8 * Constants.FieldSegmentSize, 1 * Constants.FieldSegmentSize),
                new Point(7 * Constants.FieldSegmentSize, 10 * Constants.FieldSegmentSize),
            };

            return beacons;
        }
    }
}
