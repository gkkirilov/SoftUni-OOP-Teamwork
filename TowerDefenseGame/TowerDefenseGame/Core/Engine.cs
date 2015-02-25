namespace TowerDefenseGame.Core
{
    using System.Media;
    using System.Text;
    using Controllers;
    using Enumerations;
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
            this.SetStatistics();

            if (PlayerInterfaceController.PlayerLife <= 0)
            {
                Timers.StopTimers();
                backgroundMusic.Stop();
                AnimationController.Renderer.RenderGameOver();
            }
        }

        private void SetStatistics()
        {
            Statistics.SetWaveCounter(EnemyController.WaveCount.ToString());
            Statistics.SetMoney(PlayerInterfaceController.Money.ToString());
            Statistics.SetLife(PlayerInterfaceController.PlayerLife.ToString());
            Statistics.SetKilledEnemies();

            if (PlayerInterfaceController.TowerSelected != null)
            {
                StringBuilder info = new StringBuilder();
                info.Append("Level: ");
                info.Append(PlayerInterfaceController.TowerSelected.Level.ToString());
                info.Append("\nDamage: ");
                info.Append(PlayerInterfaceController.TowerSelected.Damage.ToString());
                info.Append("\nRange: ");
                info.Append(PlayerInterfaceController.TowerSelected.Range.ToString());

                Statistics.SetTowerInfo(info.ToString());
                Statistics.SetUpgradePrice(PlayerInterfaceController.TowerSelected.Price.ToString());
                Statistics.SetRemovePrice(((PlayerInterfaceController.TowerSelected.Price) / 3).ToString());
            }

            switch (PlayerInterfaceController.TowerTypeSelected)
            {
                case TowerType.Arrow:  
                    Statistics.SetTowerInformation(Constants.ArrowTowerInformation.ToString());
                    break;             
                case TowerType.Fire:  
                    Statistics.SetTowerInformation(Constants.FireTowerInformation.ToString());
                    break;             
                case TowerType.Freeze: 
                    Statistics.SetTowerInformation(Constants.FreezeTowerInformation.ToString());
                    break;             
                case TowerType.Sniper: 
                    Statistics.SetTowerInformation(Constants.SniperTowerInformation.ToString());
                    break;
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
