namespace TowerDefenseGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using TowerDefenseGame.Controllers;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Interfaces;
    using TowerDefenseGame.Models;
    using TowerDefenseGame.Models.Enemies;

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
            EnemyController.Render();
            TowerController.Render();
            GameFieldController.Render();
            ProjectileController.Render();        
        }
    }
}
