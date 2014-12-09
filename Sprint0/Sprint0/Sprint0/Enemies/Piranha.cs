using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Enemies
{
    public class Piranha : IEnemy
    {
        bool found;

        private static ISprite PiranhaSprite = new Sprites.GreenPlantSprite();
        private int xPosition;
        private int yPosition;
        private Camera camera;

        public Piranha(int x, int y, Camera cam)
        {
            camera = cam;
            found = false;
            xPosition = x;
            yPosition = y;
        }

       

        public void Draw()
        {
            camera.Draw(PiranhaSprite, xPosition, yPosition);
        }
        public void Fall(int f)
        {

        }

        public void Reverse(int w)
        {
        }

        public void Update(IList<IBlock> blocks, IList<IEnemy> enemies)
        {
            int cam = camera.CameraPos();
            if ((cam + Constants.enemyWakeDistance) > xPosition)
            {
                found = true;
            }
            if (found)
            {
                PiranhaSprite.Update();
            }
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, PiranhaSprite.GetWidth(), PiranhaSprite.GetHeight());
        }
    }
}
