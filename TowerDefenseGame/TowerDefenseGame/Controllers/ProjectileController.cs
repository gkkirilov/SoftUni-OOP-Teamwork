using System;
using System.Collections.Generic;
using TowerDefenseGame.Models.Projectiles;

namespace TowerDefenseGame.Controllers
{
    public static class ProjectileController
    {
        private static List<Projectile> projectiles = new List<Projectile>();

        public static List<Projectile> Projectiles
        {
            get
            {
                return ProjectileController.projectiles;
            }
        }

        public static void Update()
        {
            for (int index = 0; index < ProjectileController.Projectiles.Count; index++)
            {
                ProjectileController.Projectiles[index].Update();
                if (!ProjectileController.Projectiles[index].Exists)
                {
                    AnimationController.Renderer.RemoveModel(ProjectileController.Projectiles[index]);
                    ProjectileController.Projectiles.RemoveAt(index);
                    index--;
                }
            }
        }

        public static void Render()
        {
            foreach (Projectile projectile in ProjectileController.Projectiles)
            {
                AnimationController.Renderer.Render(projectile);
            }
        }
    }
}
