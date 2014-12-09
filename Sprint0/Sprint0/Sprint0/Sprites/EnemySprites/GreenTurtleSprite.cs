using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Sprites
{
    class GreenTurtleSprite : ISprite
    {
        private static SpriteBatch spritebatch;
        private static List<Texture2D> frames;
        private int currentFrame;
        private int currentTick;
        public void Update()
        {
            currentTick++;
            if (currentTick == Constants.ticksPerFrame)
            {
                currentTick = 0;
                currentFrame++;
                if (currentFrame >= frames.Count()) currentFrame = 0;
            }

        }
        public void Draw(int x, int y, SpriteEffects facing)
        {
            spritebatch.Draw(frames[currentFrame], new Vector2(x, y), new Rectangle(0, 0, frames[currentFrame].Width, frames[currentFrame].Height), Color.White, 0, new Vector2(0, 0), 1, facing, 0);

        }
      //  spritebatch.Draw(frames[currentFrame], new Rectangle(x, y, frames[currentFrame].Width, frames[currentFrame].Height), Color.White, facing);
        public GreenTurtleSprite()
        {
            currentFrame = 0;
            currentTick = 0;
        }

        public int GetWidth()
        {
            return frames[currentFrame].Width;
        }

        public int GetHeight()
        {
            return frames[currentFrame].Height;
        }
        static public void Init(SpriteBatch batch, List<Texture2D> f)
        {
            if (spritebatch == null)
            {
                spritebatch = batch;
                frames = f;
            }
        }
    }
}
