using System;
using System.Collections.Generic;
using TowerDefenseGame.Models.Enemies;
using TowerDefenseGame.Core;
using System.Windows.Shapes;
using System.Windows.Controls;
using Animations.AnimationInterfaces;
using TowerDefenseGame.Models;
using TowerDefenseGame.Geometry;
using System.Windows.Media;
using System.Windows.Threading;
using Animations;
using TowerDefenseGame.Controllers;
using TowerDefenseGame.Interfaces;

namespace TowerDefenseGame.Core
{
    class Engine : IEngine
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
			ProjectileController.Update();        }

        public void Render()
        {
            EnemyController.Render();
			TowerController.Render();
			GameFieldController.Render();
			ProjectileController.Render();        }
    }
}
