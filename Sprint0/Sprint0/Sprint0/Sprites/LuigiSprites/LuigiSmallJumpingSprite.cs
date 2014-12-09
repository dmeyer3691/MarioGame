using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Sprites
{
    class LuigiSmallJumpingSprite : ISprite
    {
        private static SpriteBatch spritebatch;
        private static Texture2D frame;
        public void Update()
        {
            //static nothing to do
        }
        public void Draw(int x, int y, SpriteEffects facing)
        {
            spritebatch.Draw(frame, new Vector2(x, y), new Rectangle(0, 0, frame.Width, frame.Height), Color.White, 0, new Vector2(0, 0), 1, facing, 0);
        }

        public LuigiSmallJumpingSprite()
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
