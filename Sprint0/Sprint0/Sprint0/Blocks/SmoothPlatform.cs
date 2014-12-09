using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Blocks
{
    class SmoothPlatform : IBlock
    {
        private static ISprite SmoothPlatformSprite = new Sprites.SmoothPlatformSprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public SmoothPlatform(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Draw()
        {
            camera.Draw(SmoothPlatformSprite, xPosition, yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, SmoothPlatformSprite.GetWidth(), SmoothPlatformSprite.GetHeight());
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound) { }



    }
}
