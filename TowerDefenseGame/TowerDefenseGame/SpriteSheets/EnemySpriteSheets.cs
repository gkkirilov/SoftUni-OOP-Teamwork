using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.SpriteSheets
{
    static class EnemySpriteSheets
    {
        public static readonly BitmapImage goblin = new BitmapImage(
            new Uri(@"..\..\Common\goblinsword.png",
                UriKind.Relative));

    }
}
