namespace TowerDefenseGame.Utilities
{
    using System;
    using System.Windows.Threading;
    using Controllers;
    using Interfaces;

    public static class Timers
    {
        private static readonly DispatcherTimer UpdateTimer = new DispatcherTimer();
        private static readonly DispatcherTimer RenderTimer = new DispatcherTimer();
        private static readonly DispatcherTimer EnemyGenerator = new DispatcherTimer();
        private static readonly DispatcherTimer WaveDelayTimer = new DispatcherTimer();

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
