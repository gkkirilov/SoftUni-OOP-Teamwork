using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TowerDefenseGame.Interfaces;


namespace Animations.AnimationInterfaces
{
    interface IRenderer
    {
        void Render(object obj);

        void RemoveModel(IGameObject gameObject);

        void Clear();
    }
}