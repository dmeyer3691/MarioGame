using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Sprites
{
    class FireflowerSprite : ISprite
    {
        private static SpriteBatch spritebatch;
        private static Texture2D frame;
        public void Update()
        {
            //static nothing to do
        }
        public void Draw(int x, int y, SpriteEffects facing)
        {
            spritebatch.Draw(frame, new Rectangle(x, y, frame.Width, frame.Height), Color.White);
        }

        public FireflowerSprite()
        {
            //nothing to do here
        }

        static public void Init(SpriteBatch batch, Texture2D f)
        {
            if (spritebatch == null)
            {
                spritebatch = batch;
                frame = f;
            }
        }
        public int GetWidth()
        {
            return frame.Width;
        }

        public int GetHeight()
        {
            return frame.Height;
        }
    }
}
