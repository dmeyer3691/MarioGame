using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Blocks
{
    public class Flagpole : IBlock
    {
        private static ISprite FlagpoleSprite = new Sprites.FlagpoleSprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public Flagpole(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Draw()
        {
            camera.Draw(FlagpoleSprite, xPosition, yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            //flagpole's rectangle is weird. Besides that, when Mario touches flagpole, Mario gets removed and FlagMario performs its show, so Flagpole collisions are handled directly by Level.
            return new Rectangle(xPosition, yPosition, 0,0);
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound) { }


    }
}

