using System.Windows.Controls;

namespace TowerDefenseGame.Interfaces
{
    public interface IRenderer
    {
        void Render(object obj);

        void RemoveModel(IGameObject gameObject);

        void Clear();

        void DrawText(TextBlock text, int x, int y);
    }
}