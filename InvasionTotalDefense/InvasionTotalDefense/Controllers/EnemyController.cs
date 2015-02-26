namespace TowerDefenseGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models.Enemies;
    using Utilities;

    public static class EnemyController
    {
        private static List<IEnemy> enemies = new List<IEnemy>();
        private static int waveEnemiesCount = 0;
        private static int waveCount = 0;
        private static int enemyTypeCounter = -1;

        public static List<IEnemy> Enemies
        {
            get
            {
                return enemies;
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
                return waveEnemiesCount;
            }

            set
            {
                waveEnemiesCount = value;
            }
        }

        public static void Update() 
        {
            for (int index = 0; index < Enemies.Count; index++)
            {
                Enemies[index].Update();

                if (!Enemies[index].Exists)
                {
                    PlayerInterfaceController.Money += Enemies[index].Bounty;
                    RemoveEnemy(index);
                    index--;
                    Statistics.IncrementKilledEnemies();
                }
                else if (Enemies[index].HasExited)
                {
                    PlayerInterfaceController.PlayerLife--;
                    RemoveEnemy(index);
                    index--;
                }
            }
        }

        public static void GenerateEnemy(int x, int y)
        {
            WaveEnemiesCount++;
            switch (enemyTypeCounter)
            {
                case 0:
                    Enemies.Add(new Skeleton(x, y));
                    break;
                case 1:
                    Enemies.Add(new Goblin(x, y));
                    break;
                case 2:
                    Enemies.Add(new Zombie(x, y));
                    break;
                case 3:
                    Enemies.Add(new GrimReaper(x, y));
                    break;
                default:
                    enemyTypeCounter = 0;
                    Enemies.Add(new Skeleton(x, y));
                    break;
            }
        }

        public static void Render()
        {
            foreach (var enemy in Enemies)
            {
                AnimationController.Renderer.Render(enemy);
                AnimationController.Renderer.RenderHealthBar(enemy);
            }
        }

        private static void RemoveEnemy(int index)
        {
            AnimationController.Renderer.RemoveHealthBar(Enemies[index]);
            AnimationController.Renderer.RemoveModel(Enemies[index]);
            Enemies.RemoveAt(index);
        }
    }
}
