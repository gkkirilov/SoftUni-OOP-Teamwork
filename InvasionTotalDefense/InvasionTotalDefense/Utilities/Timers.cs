namespace TowerDefenseGame.Utilities
{
    using System;
    using System.Windows.Threading;
    using Controllers;
    using Interfaces;
    using Models.Enemies;

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
                engine.Update();
            };

            RenderTimer.Interval = TimeSpan.FromMilliseconds(Constants.UpdateDelay);
            RenderTimer.Tick += (obj, args) =>
            {
                engine.Render();
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
                if (EnemyController.WaveCount % 4 == 1 && EnemyController.WaveCount != 1)
                {
                    Enemy.Upgrade();
                }
            };

            WaveDelayTimer.Start();
        }

        public static void StopTimers()
        {
            WaveDelayTimer.Stop();
            EnemyGenerator.Stop();
            UpdateTimer.Stop();
            RenderTimer.Stop();
        }
    }
}
