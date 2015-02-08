using System;
using System.Windows.Threading;
using TowerDefenseGame.Controllers;
using TowerDefenseGame.Interfaces;

namespace TowerDefenseGame.Core
{
    static class Timers
    {
        private static DispatcherTimer enemyGeneratorTimer = new DispatcherTimer();
        private static DispatcherTimer updateTimer = new DispatcherTimer();
        private static DispatcherTimer renderTimer = new DispatcherTimer();
        private static DispatcherTimer waveDelayTimer = new DispatcherTimer();

        public static DispatcherTimer WaveDelayTimer
        {
            get
            {
                return Timers.waveDelayTimer;
            }
        }

        public static DispatcherTimer UpdateTimer
        {
            get
            {
                return Timers.updateTimer;
            }
        }

        public static DispatcherTimer RenderTimer
        {
            get
            {
                return Timers.renderTimer;
            }
        }

        public static DispatcherTimer EnemyGeneratorTimer
        {
            get
            {
                return Timers.enemyGeneratorTimer;
            }
        }

        public static void InitializeTimers(IEngine engine)
        {
            Timers.EnemyGeneratorTimer.Interval = TimeSpan.FromMilliseconds(Constants.EnemyGenerationDelay);
            Timers.EnemyGeneratorTimer.Tick += (obj, args) =>
            {
                EnemyController.GenerateEnemy(Constants.EnemyStartCol * Constants.FieldSegmentSize,
                                   Constants.EnemyStartRow * Constants.FieldSegmentSize);
            };

            Timers.UpdateTimer.Interval = TimeSpan.FromMilliseconds(Constants.UpdateDelay);
            Timers.UpdateTimer.Tick += (obj, args) =>
            {
                engine.Update();
            };

            Timers.RenderTimer.Interval = TimeSpan.FromMilliseconds(Constants.RenderDelay);
            Timers.RenderTimer.Tick += (obj, args) =>
            {
                engine.Render();
            };

            Timers.WaveDelayTimer.Interval = TimeSpan.FromMilliseconds(Constants.WaveDelay);
            Timers.WaveDelayTimer.Tick += (obj, args) =>
            {
                Timers.EnemyGeneratorTimer.Start();
                Timers.WaveDelayTimer.Stop();
            };
        }
    }
}
