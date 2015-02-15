namespace TowerDefenseGame.Controllers
{
    using System;
    using System.Windows.Controls;
    using TowerDefenseGame.Core;
    using TowerDefenseGame.Interfaces;

    public static class AnimationController
    {
        private static IRenderer renderer;

        public static IRenderer Renderer
        {
            get
            {
                return AnimationController.renderer;
            }

            private set
            {
                AnimationController.renderer = value;
            }
        }

        public static void ConfigureRenderer(Canvas canvas)
        {
            AnimationController.Renderer = new Renderer(canvas);
        }
    }
}
