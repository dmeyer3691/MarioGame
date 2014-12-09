using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Blocks
{
    class Castle : IBlock {
        private static ISprite CastleSprite = new Sprites.CastleSprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public Castle(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Draw()
        {
            camera.Draw(CastleSprite, xPosition, yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, 0, 0);//no collisions with castles
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound) { }


    }
}

