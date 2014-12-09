using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Sprites
{
    public class MarioSmallWalkingSprite : ISprite
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
            Texture2D frame = frames[currentFrame];
            spritebatch.Draw(frame, new Vector2(x, y), new Rectangle(0, 0, frame.Width, frame.Height), Color.White, 0, new Vector2(0, 0), 1, facing, 0);

        }
        
        public MarioSmallWalkingSprite(SpriteBatch batch, List<Texture2D> f)
        {
            currentFrame = 0;
            currentTick = 0;
            Init(batch, f);
        }
        static public void Init(SpriteBatch batch, List<Texture2D> f)
        {
            if (spritebatch == null)
            {
                spritebatch = batch;
                frames = f;
            }
        }
        public int GetWidth()
        {
            return frames[currentFrame].Width;
        }

        public int GetHeight()
        {
            return frames[currentFrame].Height;
        }
    }
}
