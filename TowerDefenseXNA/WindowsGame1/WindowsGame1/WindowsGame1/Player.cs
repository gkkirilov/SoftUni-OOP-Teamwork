using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowsGame1
{
    class Player
    {
        private int gold = 50;
        private int lives = 30;
        private List<Tower> towers = new List<Tower>();
        private MouseState mouseState; // Mouse state for the current frame
        private MouseState oldState; // Mouse state for the previous frame
        private Level level;
        private int cellX;
        private int cellY;
        private int tileX;
        private int tileY;
        private Texture2D towerTexture;
        private Texture2D bulletTexture;

        public Player(Level level, Texture2D towerTexture, Texture2D bulletTexture)
        {
            this.level = level;
            this.towerTexture = towerTexture;
            this.bulletTexture = bulletTexture;
        }
        public void Update(GameTime gameTime, List<Enemy> enemies)
        {
            mouseState = Mouse.GetState();

            cellX = (int)(mouseState.X / 32); // Convert the position of the mouse
            cellY = (int)(mouseState.Y / 32); // from array space to level space

            tileX = cellX * 32; // Convert from array space to level space
            tileY = cellY * 32; // Convert from array space to level space
            if(mouseState.LeftButton == ButtonState.Released &&
                oldState.LeftButton == ButtonState.Pressed)
            {
                if (IsCellClear())
                {

                    ArrowTower tower = new ArrowTower(towerTexture,
                     bulletTexture, new Vector2(tileX, tileY));

                    towers.Add(tower);

                }
            }
            foreach (Tower tower in towers)
            {
                if (tower.Target == null)
                {
                    tower.GetClosestEnemy(enemies);
                }

                tower.Update(gameTime);
            }

            oldState = mouseState; // Set the oldState so it becomes the state of the previous frame.
        }


        public int Gold
        {
            get { return gold; }
        }
        public int Lives
        {
            get { return lives; }
        }
        public Player(Level level)
        {
            this.level = level;
        }

        private bool IsCellClear()
        {
            bool inBounds = cellX >= 0 && cellY >= 0 &&
                cellX < level.Width && cellY < level.Height;
            bool spaceClear = true;
            foreach (Tower tower in towers) // Check that there is no tower here
            {
                spaceClear = (tower.Position != new Vector2(tileX, tileY));

                if (!spaceClear)
                    break;
            }
            bool onPath = (level.GetIndex(cellX, cellY) != 1);
            return inBounds && spaceClear && onPath;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tower tower in towers)
            {
                tower.Draw(spriteBatch);
            }
        }
    }
}
