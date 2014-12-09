using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Items
{
    public class Oneup : IItem
    {
        private Collisions.ItemAllCollision itemAllCollisions;
        bool movingRight;

        private ISprite OneUpSprite = new Sprites.OneUpSprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public Oneup(int x, int y, Camera cam)
        {
            itemAllCollisions = new Collisions.ItemAllCollision(this);
            movingRight = true;
            camera = cam;
            xPosition = x;
            yPosition = y;
        }


        public void Reverse()
        {
            if (movingRight)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }
        }

        public void Draw()
        {
            camera.Draw(OneUpSprite, xPosition, yPosition);
        }


        public String GetItemName()
        {
            return "Oneup";
        }

        public void Update(IList<IBlock> blocks)
        {
            yPosition++;
            itemAllCollisions.ItemCollisionTest(blocks);

            if (movingRight)
            {
                xPosition++;
            }
            else
            {
                xPosition--;
            }
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, OneUpSprite.GetWidth(), OneUpSprite.GetHeight());
        }
        public void moveYPosition(int offset)
        {
            yPosition += offset;
        }
        public bool DestroyItem() { return false; }
    }
}
