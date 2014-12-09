using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Blocks
{
    class GreenBrick : IBlock
    {
        private ISprite GreenBrickSprite = new Sprites.BrickSprite();//todo: make it green
        private int xPosition;
        private int yPosition;
        Camera camera;

        public GreenBrick(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Draw()
        {
            if(GreenBrickSprite != null) camera.Draw(GreenBrickSprite, xPosition, yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            if (GreenBrickSprite == null) return new Rectangle(xPosition, yPosition, 0, 0);
            return new Rectangle(xPosition, yPosition, GreenBrickSprite.GetWidth(), GreenBrickSprite.GetHeight());
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound) {
            if (isBig)
            {
                sound.BreakBlock();
                hud.increaseScoreMario(Constants.brokenBrickValue);
                GreenBrickSprite = null;
            }
        }


    }
}
