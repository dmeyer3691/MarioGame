using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Blocks
{
    class RoughPlatform : IBlock
    {
        private static ISprite RoughPlatformSprite = new Sprites.RoughPlatformSprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public RoughPlatform(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Draw()
        {
            camera.Draw(RoughPlatformSprite, xPosition, yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, RoughPlatformSprite.GetWidth(), RoughPlatformSprite.GetHeight());
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound) { }


    }
}
