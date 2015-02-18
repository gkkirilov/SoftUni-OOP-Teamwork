namespace TowerDefenseGame.Core
{
    using System;
    using System.Windows.Threading;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Interfaces;

    public static class Timers
    {
        private static DispatcherTimer updateTimer = new DispatcherTimer();

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
                engine.Update();
                engine.Render();
            };
        }
    }
}
