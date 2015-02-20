namespace TowerDefenseGame.Controllers
{
    using System.Collections.Generic;
    using Interfaces;
    using TowerDefenseGame.Enumerations;
    using TowerDefenseGame.Models.Towers;

    public static class TowerController
    {
        private static List<ITower> towers = new List<ITower>();
        private static int towerCount = 0;

        public static List<ITower> Towers
        {
            get
            {
                return TowerController.towers;
            }
        }

        public static void GenerateTower(double x, double y)
        {
            switch (PlayerInterfaceController.TowerTypeSelected)
            {
                case TowerType.Arrow:
                    if (PlayerInterfaceController.Money < ArrowTower.TowerPrice)
                    {
                        return;
                    }
                    PlayerInterfaceController.Money -= ArrowTower.TowerPrice;
                    TowerController.Towers.Add(new ArrowTower(x, y));
                    break;
                case TowerType.Fire:
                    if (PlayerInterfaceController.Money < FireTower.TowerPrice)
                    {
                        return;
                    }
                    PlayerInterfaceController.Money -= FireTower.TowerPrice;
                    TowerController.Towers.Add(new FireTower(x, y));
                    break;
                case TowerType.Slow:
                    if (PlayerInterfaceController.Money < SlowTower.TowerPrice)
                    {
                        return;
                    }
                    PlayerInterfaceController.Money -= SlowTower.TowerPrice;
                    TowerController.Towers.Add(new SlowTower(x, y));
                    break;
                case TowerType.Sniper:
                    if (PlayerInterfaceController.Money < SniperTower.TowerPrice)
                    {
                        return;
                    }
                    PlayerInterfaceController.Money -= SniperTower.TowerPrice;
                    TowerController.Towers.Add(new SniperTower(x, y));
                    break;
                default:
                    break;
            }
            TowerController.towerCount++;
        }

        public static void Update()
        {
            for (int index = 0; index < TowerController.Towers.Count; index++)
            {
                TowerController.Towers[index].Update();
                if (!TowerController.Towers[index].Exists)
                {
                    TowerController.Towers.RemoveAt(index);
                    index--;
                }
            }
        }
        
        public static void Render()
        {
            foreach (var tower in TowerController.Towers)
            {
                AnimationController.Renderer.Render(tower);
            }
        }

        public static void RemoveTower(ITower towerToRemove)
        {
            AnimationController.Renderer.RemoveModel(towerToRemove);
            Towers.Remove(towerToRemove);
        }
    }
}
