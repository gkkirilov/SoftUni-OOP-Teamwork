﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Bullet : Sprite
    {
        private int damage;
        private int age;
        private int speed;

        
        public Bullet(Texture2D texture, Vector2 position, float rotation,
            int speed, int damage)
            : base(texture, position)
        {
            this.rotation = rotation;
            this.damage = damage;
            this.speed = speed;
        }

        public bool IsDead()
        {
            return age > 100;
        }
        public void Kill()
        {
            this.age = 200;
        }

        public override void Update(GameTime gameTime)
        {
            age++;
            position += velocity;

            base.Update(gameTime);
        }
        public void SetRotation(float value)
        {
            rotation = value;

            velocity = Vector2.Transform(new Vector2(0, -speed),
                Matrix.CreateRotationZ(rotation));
        }
    }
}