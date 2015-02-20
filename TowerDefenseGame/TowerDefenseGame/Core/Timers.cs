namespace TowerDefenseGame.Core
{
    using System;
    using System.Windows.Threading;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Interfaces;

    public static class Timers
    {
        private static DispatcherTimer updateTimer = new DispatcherTimer();
        private static DispatcherTimer renderTimer = new DispatcherTimer();
        private static DispatcherTimer enemyGenerator = new DispatcherTimer();
        private static DispatcherTimer waveDelayTimer = new DispatcherTimer();

        public static DispatcherTimer EnemyGenerator
        {
            get
            {
                return enemyGenerator;
            }
        }

        public static DispatcherTimer UpdateTimer
        {
            get
            {
                return updateTimer;
            }
        }

        public static DispatcherTimer RenderTimer
        {
            get
            {
                return renderTimer;
            }
        }

        public static DispatcherTimer WaveDelayTimer
        {
            get
            {
                return waveDelayTimer;
            }
        }

        public static void InitializeTimers(IEngine engine)
        {
            UpdateTimer.Interval = TimeSpan.FromMilliseconds(Constants.UpdateDelay);
            UpdateTimer.Tick += (obj, args) =>
            {
                if (PlayerInterfaceController.PlayerLife >= 1)
                {
                    engine.Update();
                }
                else
                {
                    // TODO: GameOver
                    Console.WriteLine("gameOver");
                }
            };

            RenderTimer.Interval = TimeSpan.FromMilliseconds(Constants.UpdateDelay);
            RenderTimer.Tick += (obj, args) =>
            {
                if (PlayerInterfaceController.PlayerLife >= 1)
                {
                    engine.Render();
                }
                else
                {
                    // TODO: GameOver
                    Console.WriteLine("gameOver");
                }
            };
            RenderTimer.Start();
            UpdateTimer.Start();

            EnemyGenerator.Interval = TimeSpan.FromMilliseconds(Constants.EnemyGenerationDelay);
            EnemyGenerator.Tick += (obj, args) =>
            {
                EnemyController.GenerateEnemy(
                    Constants.EnemyStartCol * Constants.FieldSegmentSize,
                    Constants.EnemyStartRow * Constants.FieldSegmentSize);

                if (EnemyController.WaveEnemiesCount >= Constants.WaveEnemiesMaxCount)
                {
                    EnemyController.WaveEnemiesCount = 0;
                    EnemyGenerator.Stop();
                    WaveDelayTimer.Start();
                }
            };

            WaveDelayTimer.Interval = TimeSpan.FromMilliseconds(Constants.WaveDelay);
            WaveDelayTimer.Tick += (obj, args) =>
            {
                EnemyGenerator.Start();
                WaveDelayTimer.Stop();
                EnemyController.WaveCount++;
                EnemyController.EnemyTypeCounter++;
            };

            WaveDelayTimer.Start();
        }
    }
}
