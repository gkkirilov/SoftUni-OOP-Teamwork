using System;
using System.Windows.Shapes;
using TowerDefenseGame.Geometry;

namespace TowerDefenseGame.Interfaces
{
    interface IGameObject
    {
        Point Coordinates { get; set; }
        int Width { get; }
        int Height { get; }

        Rectangle Model { get; }
    }
}
