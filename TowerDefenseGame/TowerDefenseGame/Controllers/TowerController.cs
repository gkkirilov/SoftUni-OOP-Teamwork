namespace TowerDefenseGame.Controllers
{
    using System.Collections.Generic;
    using TowerDefenseGame.Enumerations;
    using TowerDefenseGame.Models.Towers;

    public static class TowerController
    {
        private static List<Tower> towers = new List<Tower>();
        private static int towerCount = 0;

        public static List<Tower> Towers
        {
            get
            {
                return TowerController.towers;
            }
        }

        public static void GenerateTower(double x, double y)
        {
            switch (PlayerInterfaceController.TowerSelected)
            {
                case TowerType.Arrow:
                    if (PlayerInterfaceController.Money < ArrowTower.Price)
                    {
                        break;
                    }
                    PlayerInterfaceController.Money -= ArrowTower.Price;
                    TowerController.Towers.Add(new ArrowTower(x, y));
                    break;
                case TowerType.Fire:
                    if (PlayerInterfaceController.Money < FireTower.Price)
                    {
                        break;
                    }
                    PlayerInterfaceController.Money -= FireTower.Price;
                    TowerController.Towers.Add(new FireTower(x, y));
                    break;
                case TowerType.Slow:
                    if (PlayerInterfaceController.Money < SlowTower.Price)
                    {
                        break;
                    }
                    PlayerInterfaceController.Money -= SlowTower.Price;
                    TowerController.Towers.Add(new SlowTower(x, y));
                    break;
                case TowerType.Sniper:
                    if (PlayerInterfaceController.Money < SniperTower.Price)
                    {
                        break;
                    }
                    PlayerInterfaceController.Money -= SniperTower.Price;
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
    }
}
