using System;
using TowerDefenseGame.Enumerations;

namespace TowerDefenseGame.Controllers
{
    static class PlayerInterfaceController
    {
        private static TowerType towerSelected = TowerType.Sniper;

        public static TowerType TowerSelected
        {
            get
            {
                return PlayerInterfaceController.towerSelected;
            }
            set
            {
                PlayerInterfaceController.towerSelected = value;
            }
        }
    }
}
