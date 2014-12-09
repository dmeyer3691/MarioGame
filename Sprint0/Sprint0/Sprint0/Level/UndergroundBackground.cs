using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi
{
    class UndergroundBackground : IBlock
    {
        private ISprite BackgroundSprite = new Sprites.BlackRectangleSprite();
        Camera camera;

        public UndergroundBackground(Camera cam)
        {
            camera = cam;
        }


        public void Draw()
        {
            camera.Draw(BackgroundSprite, Constants.undergroundSectionDepth, Constants.levelHeight);
            camera.Draw(BackgroundSprite, Constants.undergroundSectionDepth, 0);

        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, 0, 0, 0);//don't collide
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD h,SoundEffects s) { }



    }
}
