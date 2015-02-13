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
            foreach (Projectile projectile in ProjectileController.Projectiles)
            {
                projectile.Update();
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
