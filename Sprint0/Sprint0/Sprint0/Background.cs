using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi
{
    class Background
    {
        private ISprite BackgroundSprite = new Sprites.BackgroundSprite();
        private static int yPosition = 240;
        Camera camera;

        public Background(Camera cam)
        {
            camera = cam;
        }


        public void Draw()
        {
            //not quite right yet, I think I need to hardcode in the screen width.
            camera.Draw(BackgroundSprite,camera.CameraPos(), yPosition);
            camera.Draw(BackgroundSprite,camera.CameraPos() - BackgroundSprite.GetWidth(), yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(0, yPosition, BackgroundSprite.GetWidth(), BackgroundSprite.GetHeight());
        }

        public void Hit(IList<IItem> items, bool marioIsBig) { }



    }
}
