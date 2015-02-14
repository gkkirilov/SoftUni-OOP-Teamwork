using System;
using System.Windows.Shapes;
using TowerDefenseGame.Geometry;
using TowerDefenseGame.Models;

namespace TowerDefenseGame.Interfaces
{
    interface IGameObject
    {
        Point Coordinates { get; set; }
        int Width { get; }
        int Height { get; }
        Rectangle Model { get; }
        bool Intersects(GameObject target);
        void Update();
    }
}
