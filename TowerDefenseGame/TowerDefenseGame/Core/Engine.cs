namespace TowerDefenseGame.Core
{
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Interfaces;

    public class Engine : IEngine
    {
        public Engine()
        {
            GameFieldController.Initialize();
            Timers.InitializeTimers(this);

            Timers.UpdateTimer.Start();
        }

        public void Update()
        {
            EnemyController.Update();
            TowerController.Update();
            ProjectileController.Update();        
        }

        public void Render()
        {
            TowerController.Render();
            EnemyController.Render();
            ProjectileController.Render();        
        }
    }
}
