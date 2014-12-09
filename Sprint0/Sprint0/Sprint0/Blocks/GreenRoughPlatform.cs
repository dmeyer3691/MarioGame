using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Blocks
{
    class GreenRoughPlatform : IBlock
    {
        private static ISprite GreenRoughPlatformSprite = new Sprites.RoughPlatformSprite();//todo: make it green
        private int xPosition;
        private int yPosition;
        Camera camera;

        public GreenRoughPlatform(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Draw()
        {
            camera.Draw(GreenRoughPlatformSprite, xPosition, yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, GreenRoughPlatformSprite.GetWidth(), GreenRoughPlatformSprite.GetHeight());
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound) { }


    }
}
