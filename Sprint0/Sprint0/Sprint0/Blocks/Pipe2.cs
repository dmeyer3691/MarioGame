using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Blocks
{
    class Pipe2 : IBlock
    {
        private static ISprite Pipe2Sprite = new Sprites.Pipe2Sprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public Pipe2(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Draw()
        {
            camera.Draw(Pipe2Sprite, xPosition, yPosition);
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, Pipe2Sprite.GetWidth(), Pipe2Sprite.GetHeight());
        }

        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound) { }



    }
}
