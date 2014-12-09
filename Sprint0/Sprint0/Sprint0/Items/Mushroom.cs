using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Items
{
    public class Mushroom : IItem
    {


        private Collisions.ItemAllCollision itemAllCollisions;
        private bool movingRight;

        private ISprite MushroomSprite = new Sprites.MushroomSprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public Mushroom(int x, int y, Camera cam)
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
            camera.Draw(MushroomSprite, xPosition, yPosition);
        }


        public String GetItemName()
        {
            return "Mushroom";
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

            MushroomSprite.Update();
        }


        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, MushroomSprite.GetWidth(), MushroomSprite.GetHeight());
        }
        public void moveYPosition(int offset)
        {
            yPosition += offset;
        }
        public bool DestroyItem() { return false; }
    }
}
