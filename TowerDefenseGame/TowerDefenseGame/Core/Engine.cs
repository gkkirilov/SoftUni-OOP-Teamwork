namespace TowerDefenseGame.Core
{
    using System.Media;
    using Controllers;
    using Interfaces;
    using Utilities;

    public class Engine : IEngine
    {
        private SoundPlayer backgroundMusic;

        public Engine()
        {
            GameFieldController.Initialize();
            Timers.InitializeTimers(this);
            PlayerInterfaceController.Money = Constants.StartingMoney;
            PlayerInterfaceController.PlayerLife = Constants.PlayerStartingLife;

            backgroundMusic = new SoundPlayer(@"..\..\Resources\music.wav");
            backgroundMusic.PlayLooping();
        }

        public void Update()
        {
            EnemyController.Update();
            TowerController.Update();
            ProjectileController.Update();  
            Statistics.Update();

            if (PlayerInterfaceController.PlayerLife <= 0)
            {
                Timers.StopTimers();
                backgroundMusic.Stop();
                AnimationController.Renderer.RenderGameOver();
            }
        }

        public void Render()
        {
            TowerController.Render();
            EnemyController.Render();
            ProjectileController.Render();    
            Statistics.Render();
        }
    }
}
