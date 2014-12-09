using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Items
{
    public class Star : IItem
    {
        private Collisions.ItemAllCollision itemAllCollisions;
        private bool movingRight;

        private ISprite StarSprite = new Sprites.StarSprite();
        private int xPosition;
        private int yPosition;
        private Camera camera;

        public Star(int x, int y, Camera cam)
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
            camera.Draw(StarSprite, xPosition, yPosition);
        }

        public String GetItemName()
        {
            return "Star";
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

            StarSprite.Update();
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, StarSprite.GetWidth(), StarSprite.GetHeight());
        }
        public void moveYPosition(int offset)
        {
            yPosition += offset;
        }
        public bool DestroyItem() { return false; }
    }
}
