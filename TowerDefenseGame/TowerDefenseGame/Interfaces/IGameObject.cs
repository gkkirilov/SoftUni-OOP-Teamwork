namespace TowerDefenseGame.Interfaces
{
    using System.Windows.Shapes;
    using TowerDefenseGame.Geometry;
    using TowerDefenseGame.Models;

    public interface IGameObject
    {
        Point Coordinates { get; set; }
        
        int Width { get; }
        
        int Height { get; }
        
        Rectangle Model { get; }
        bool Exists { get; }

        bool Intersects(IGameObject target);
        
        void Update();
    }
}
