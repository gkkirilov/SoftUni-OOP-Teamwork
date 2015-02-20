namespace TowerDefenseGame.Controllers
{
    using System;
    using Interfaces;
    using TowerDefenseGame.Enumerations;

    public static class PlayerInterfaceController
    {
        private static TowerType towerTypeSelected = TowerType.Sniper;
        private static ITower towerSelected;

        private static int money;

        public static int PlayerLife { get; set; }

        public static int TowerInfo { get; set; }

        public static int Money 
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
        public static TowerType TowerTypeSelected
        {
            get
            {
                return towerTypeSelected;
            }

            set
            {
                towerTypeSelected = value;
            }
        }

        public static ITower TowerSelected
        {
            get
            {
                return towerSelected;
            }

            set
            {
                towerSelected = value;
            }
        }

        public static void UpgradeSelectedTower()
        {
            if (TowerSelected == null)
            {
                return;
            }

            if (Money < TowerSelected.Price)
            {
                return;
            }

            Money -= TowerSelected.Price;
            TowerSelected.Upgrade();
        }

        public static void DestroySelectedTower()
        {
            if (TowerSelected == null)
            {
                return;
            }

            Money += TowerSelected.Price / 3;
            TowerController.RemoveTower(TowerSelected);
            TowerSelected = null;
        }
    }
}
