using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ö2_1A
{
    internal class Logo
    {
        public Microsoft.Xna.Framework.Vector2 pos;
        public int stopY;
        public int stopX;

        public int textureDeltaX;
        public int textureDeltaY;
        public Texture2D tex;

        public Logo(Microsoft.Xna.Framework.Vector2 pos, int stopY, int stopX, Texture2D tex)
        {
            this.pos = pos;
            this.stopY = stopY;
            this.stopX = stopX;
            this.tex = tex;

            Random randomSpeed = new Random();
            textureDeltaX = randomSpeed.Next(2, 10);
            textureDeltaY = randomSpeed.Next(2, 10);
        }

        public void Update()
        {

            pos.X += textureDeltaX;
            pos.Y += textureDeltaY;

            if (pos.X <= 0)
            {
                textureDeltaX *= -1;
            }
            else if (pos.X >= stopX)
            {
                textureDeltaX *= -1;
            }
            if (pos.Y <= 0)
            {
                textureDeltaY *= -1;
            }
            else if (pos.Y >= stopY)
            {
                textureDeltaY *= -1;
            }

        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(tex, pos, Microsoft.Xna.Framework.Color.White);
        }
    }
}
