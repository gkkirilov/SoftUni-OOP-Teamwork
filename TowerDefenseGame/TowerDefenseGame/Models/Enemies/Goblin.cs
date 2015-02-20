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
    public class Goblin : Enemy
    {
        private const int EnemyLifePoints = 50;
        private const int EnemySpeed = 3;
        private const int bounty = 10;


        private static readonly CroppedBitmap[][] EnemySprites = SpritesManager.GoblinSprites;

        public Goblin(double x, double y)
            : base(
                x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, Goblin.EnemyLifePoints, Goblin.EnemySpeed,
                EnemySprites, bounty)
        {

        }
    }
}
