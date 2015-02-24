namespace TowerDefenseGame.Controllers
{
    using System.Collections.Generic;
    using Interfaces;
    using Enumerations;
    using Models.Towers;
    using Utilities;

    public static class TowerController
    {
        private static List<ITower> towers = new List<ITower>();

        public static List<ITower> Towers
        {
            get
            {
                return TowerController.towers;
            }
        }

        public static bool GenerateTower(double x, double y)
        {
            switch (PlayerInterfaceController.TowerTypeSelected)
            {
                case TowerType.Arrow:
                    if (PlayerInterfaceController.Money < ArrowTower.TowerPrice)
                    {
                        return false;
                    }
                    PlayerInterfaceController.Money -= ArrowTower.TowerPrice;
                    Towers.Add(new ArrowTower(x, y));
                    break;
                case TowerType.Fire:
                    if (PlayerInterfaceController.Money < FireTower.TowerPrice)
                    {
                        return false;
                    }
                    PlayerInterfaceController.Money -= FireTower.TowerPrice;
                    Towers.Add(new FireTower(x, y));
                    break;
                case TowerType.Freeze:
                    if (PlayerInterfaceController.Money < FreezeTower.TowerPrice)
                    {
                        return false;
                    }
                    PlayerInterfaceController.Money -= FreezeTower.TowerPrice;
                    Towers.Add(new FreezeTower(x, y));
                    break;
                case TowerType.Sniper:
                    if (PlayerInterfaceController.Money < SniperTower.TowerPrice)
                    {
                        return false;
                    }
                    PlayerInterfaceController.Money -= SniperTower.TowerPrice;
                    Towers.Add(new SniperTower(x, y));
                    break;
                default:
                    return false;
            }
            return true;
        }

        public static void Update()
        {
            for (int index = 0; index < Towers.Count; index++)
            {
                TowerController.Towers[index].Update();
                if (!Towers[index].Exists)
                {
                    Towers.RemoveAt(index);
                    index--;
                }
            }
        }
        
        public static void Render()
        {
            foreach (var tower in Towers)
            {
                AnimationController.Renderer.Render(tower);
            }
        }

        public static void RemoveTower(ITower towerToRemove)
        {
            for (int row = 0; row < Constants.FieldRows; row++)
            {
                for (int col = 0; col < Constants.FieldCols; col++)
                {
                    if (GameFieldController.GameField[row][col].Coordinates.X == towerToRemove.Coordinates.X &&
                        GameFieldController.GameField[row][col].Coordinates.Y == towerToRemove.Coordinates.Y)
                    {
                        GameFieldController.GameField[row][col].IsOccupied = false;
                        AnimationController.Renderer.RemoveModel(towerToRemove);
                        Towers.Remove(towerToRemove);
                        return;
                    }
                }
            }
        }
    }
}
