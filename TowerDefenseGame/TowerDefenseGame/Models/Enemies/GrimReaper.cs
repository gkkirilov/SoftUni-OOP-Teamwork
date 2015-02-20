using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TowerDefenseGame.Core;
using TowerDefenseGame.Resources;

namespace TowerDefenseGame.Models.Enemies
{
    public class GrimReaper : Enemy
    {
        private const int EnemyLifePoints = 50;
        private const int EnemySpeed = 3;
        private const int bounty = 10;


        private static readonly CroppedBitmap[][] EnemySprites = SpritesManager.DeathSprites;

        public GrimReaper(double x, double y)
            : base(
                x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, GrimReaper.EnemyLifePoints, GrimReaper.EnemySpeed,
                EnemySprites, bounty)
        {

        }
    }
}
