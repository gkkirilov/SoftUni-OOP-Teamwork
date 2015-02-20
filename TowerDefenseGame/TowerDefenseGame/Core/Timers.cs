namespace TowerDefenseGame.Core
{
    using System;
    using System.Windows.Threading;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Interfaces;

    public static class Timers
    {
        private static DispatcherTimer updateTimer = new DispatcherTimer();
        private static DispatcherTimer timeToWave = new DispatcherTimer();
        //public static int temporaryTime = (((20 * 75) * 3) + (50 * 75)) / 1000;
        public static DispatcherTimer TimeToWave
        {
            get
            {
                return Timers.timeToWave;
            }
        }

        public static DispatcherTimer UpdateTimer
        {
            get
            {
                return Timers.updateTimer;
            }
        }

        public static void InitializeTimers(IEngine engine)
        {
            Timers.UpdateTimer.Interval = TimeSpan.FromMilliseconds(Constants.UpdateDelay);
            Timers.UpdateTimer.Tick += (obj, args) =>
            {
                if (PlayerInterfaceController.PlayerLife >= 1)
                {
                    engine.Update();
                    engine.Render();
                }
                else
                {
                    // TODO: GameOver
                    Console.WriteLine("gameOver");
                }

            };

            //Timers.TimeToWave.Interval = TimeSpan.FromMilliseconds(1000);
            //Timers.TimeToWave.Tick += (obj, args) =>
            //{
            //    temporaryTime--;
            //    if (temporaryTime <= 0)
            //    {
            //        temporaryTime = (((20 * 75)) + (50 * 75)) / 1000;
            //    }
            //};
        }
    }
}
