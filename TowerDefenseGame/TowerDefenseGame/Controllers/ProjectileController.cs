namespace TowerDefenseGame.Controllers
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using TowerDefenseGame.Enumerations;
    using TowerDefenseGame.Models.Projectiles;

    public static class ProjectileController
    {
        private static List<IProjectile> projectiles = new List<IProjectile>();

        public static List<IProjectile> Projectiles
        {
            get
            {
                return projectiles;
            }
        }

        public static void Update()
        {
            for (int index = 0; index < Projectiles.Count; index++)
            {
                Projectiles[index].Update();
                if (!Projectiles[index].Exists)
                {
                    AnimationController.Renderer.RemoveModel(Projectiles[index]);
                    Projectiles.RemoveAt(index);
                    index--;
                }
            }
        }

        public static void Render()
        {
            foreach (IProjectile projectile in Projectiles)
            {
                AnimationController.Renderer.Render(projectile);
            }
        }
    }
}
