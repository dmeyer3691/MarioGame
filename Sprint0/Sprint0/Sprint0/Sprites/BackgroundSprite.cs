using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TeamYoshi.Sprites
{
    class BackgroundSprite : ISprite
    {
        private static SpriteBatch spritebatch;
        private static Texture2D frame;
        static public void Init(SpriteBatch batch, Texture2D f)
        {
            if (spritebatch == null)
            {
                spritebatch = batch;
                frame = f;
            }
        }

        public void Draw(int x, int y, SpriteEffects e)
        {
            spritebatch.Draw(frame, new Rectangle(x, y, frame.Width, frame.Height), Color.White);
        }
        public int GetHeight()
        {
            return frame.Height;
        }
        public int GetWidth()
        {
            return frame.Width;
        }
        public void Update() { }
    }
}
