using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class Level
    {
        int[,] map = new int[,] 
        {
            {0,0,0,0,0,0,0,1,0,0,0,0,0,0,},
            {0,1,1,1,1,1,1,1,0,0,0,0,0,0,},
            {0,1,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,1,0,1,1,1,1,1,1,1,1,1,1,0,},
            {0,1,0,1,0,0,0,0,0,0,0,0,1,0,},
            {0,1,0,1,0,1,1,1,1,1,0,0,1,0,},
            {0,1,0,1,0,1,0,0,0,1,0,0,1,0,},
            {0,1,0,1,0,1,0,0,0,1,0,0,1,0,},
            {0,1,0,1,0,1,0,0,0,1,0,0,1,0,},
            {0,1,0,1,0,1,0,0,0,1,0,0,1,0,},
            {0,1,0,1,1,1,0,0,0,1,0,0,1,0,},
            {0,1,0,0,0,0,0,0,0,1,0,0,1,0,},
            {0,1,1,1,1,1,1,1,1,1,0,0,1,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,1,0,}

        };

        public int Width
        {
            get { return map.GetLength(1); }
        }
        public int Height
        {
            get { return map.GetLength(0); }
        }

        private List<Texture2D> tileTextures = new List<Texture2D>();
        private Queue<Vector2> waypoints = new Queue<Vector2>();
        public Level()
        {
            waypoints.Enqueue(new Vector2(7, 0) * 32);
            waypoints.Enqueue(new Vector2(7, 1) * 32);
            waypoints.Enqueue(new Vector2(1, 1) * 32);
            waypoints.Enqueue(new Vector2(1, 2) * 32);
            waypoints.Enqueue(new Vector2(1, 2) * 32);
            waypoints.Enqueue(new Vector2(1, 4) * 32);
            waypoints.Enqueue(new Vector2(1, 4) * 32);
            waypoints.Enqueue(new Vector2(1, 5) * 32);
            waypoints.Enqueue(new Vector2(1, 5) * 32);
            waypoints.Enqueue(new Vector2(1, 7) * 32);
            waypoints.Enqueue(new Vector2(1, 8) * 32);
            waypoints.Enqueue(new Vector2(1, 9) * 32);
            waypoints.Enqueue(new Vector2(1, 10) * 32);
            waypoints.Enqueue(new Vector2(1, 11) * 32);
            waypoints.Enqueue(new Vector2(1, 12) * 32);
            waypoints.Enqueue(new Vector2(2, 12) * 32);
            waypoints.Enqueue(new Vector2(3, 12) * 32);
            waypoints.Enqueue(new Vector2(4, 12) * 32);
            waypoints.Enqueue(new Vector2(5, 12) * 32);
            waypoints.Enqueue(new Vector2(6, 12) * 32);
            waypoints.Enqueue(new Vector2(7, 12) * 32);
            waypoints.Enqueue(new Vector2(8, 12) * 32);
            waypoints.Enqueue(new Vector2(9, 12) * 32);
            waypoints.Enqueue(new Vector2(9, 11) * 32);
            waypoints.Enqueue(new Vector2(9, 10) * 32);
            waypoints.Enqueue(new Vector2(9, 9) * 32);
            waypoints.Enqueue(new Vector2(9, 8) * 32);
            waypoints.Enqueue(new Vector2(9, 7) * 32);
            waypoints.Enqueue(new Vector2(9, 6) * 32);
            waypoints.Enqueue(new Vector2(9, 5) * 32);
            waypoints.Enqueue(new Vector2(8, 5) * 32);
            waypoints.Enqueue(new Vector2(7, 5) * 32);
            waypoints.Enqueue(new Vector2(6, 5) * 32);
            waypoints.Enqueue(new Vector2(5, 5) * 32);
            waypoints.Enqueue(new Vector2(5, 6) * 32);
            waypoints.Enqueue(new Vector2(5, 7) * 32);
            waypoints.Enqueue(new Vector2(5, 8) * 32);
            waypoints.Enqueue(new Vector2(5, 9) * 32);
            waypoints.Enqueue(new Vector2(5, 10) * 32);
            waypoints.Enqueue(new Vector2(4, 10) * 32);
            waypoints.Enqueue(new Vector2(3, 10) * 32);
            waypoints.Enqueue(new Vector2(3, 9) * 32);
            waypoints.Enqueue(new Vector2(3, 8) * 32);
            waypoints.Enqueue(new Vector2(3, 7) * 32);
            waypoints.Enqueue(new Vector2(3, 6) * 32);
            waypoints.Enqueue(new Vector2(3, 5) * 32);
            waypoints.Enqueue(new Vector2(3, 4) * 32);
            waypoints.Enqueue(new Vector2(3, 3) * 32);
            waypoints.Enqueue(new Vector2(4, 3) * 32);
            waypoints.Enqueue(new Vector2(5, 3) * 32);
            waypoints.Enqueue(new Vector2(6, 3) * 32);
            waypoints.Enqueue(new Vector2(7, 3) * 32);
            waypoints.Enqueue(new Vector2(8, 3) * 32);
            waypoints.Enqueue(new Vector2(9, 3) * 32);
            waypoints.Enqueue(new Vector2(10, 3) * 32);
            waypoints.Enqueue(new Vector2(11, 3) * 32);
            waypoints.Enqueue(new Vector2(12, 3) * 32);
            waypoints.Enqueue(new Vector2(12, 4) * 32);
            waypoints.Enqueue(new Vector2(12, 5) * 32);
            waypoints.Enqueue(new Vector2(12, 6) * 32);
            waypoints.Enqueue(new Vector2(12, 7) * 32);
            waypoints.Enqueue(new Vector2(12, 8) * 32);
            waypoints.Enqueue(new Vector2(12, 9) * 32);
            waypoints.Enqueue(new Vector2(12, 10) * 32);
            waypoints.Enqueue(new Vector2(12, 11) * 32);
            waypoints.Enqueue(new Vector2(12, 12) * 32);
            waypoints.Enqueue(new Vector2(12, 13) * 32);
            waypoints.Enqueue(new Vector2(12, 14) * 32);


        }

        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }

        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }

        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];
                    batch.Draw(texture, new Rectangle(
                        x * 32, y * 32, 32, 32), Color.White);
                }
            }
        }

        public int GetIndex(int cellX, int cellY)
        {
            if (cellX < 0 || cellX > Width || cellY < 0 || cellY > Height) return 0;
            return map[cellY, cellX];
        }

    }
}
