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
            Timers.RenderTimer.Start();
            EnemyController.GenerateNextWave();
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
            GameFieldController.Render();
            EnemyController.Render();
            ProjectileController.Render();        
        }
    }
}
