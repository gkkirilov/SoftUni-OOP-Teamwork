namespace TowerDefenseGame.Interfaces
{
    using System.Windows.Controls;

    public interface IRenderer
    {
        void Render(object obj);

        void RemoveModel(IGameObject gameObject);

        void DrawText(TextBlock text, int x, int y);

        void RenderHealthBar(IEnemy creature);

        void RemoveHealthBar(IEnemy creature);

        void RenderGameOver();
    }
}