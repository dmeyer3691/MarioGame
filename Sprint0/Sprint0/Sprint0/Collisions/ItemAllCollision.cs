using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Collisions
{
    class ItemAllCollision
    {

        private IItem myItem;

        public ItemAllCollision(IItem item)
        {
            myItem = item;
        }

        public void ItemCollisionTest(IList<IBlock> blocks)
        {
            Rectangle myRectangle = myItem.GetRectangle();
            Rectangle blockRectangle;
            Rectangle intersectionRectangle;

            foreach (IBlock block in blocks)
            {

                blockRectangle = block.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(myRectangle, blockRectangle);

                if (!intersectionRectangle.IsEmpty)
                {
                    if (intersectionRectangle.Width >= intersectionRectangle.Height)
                    {
                        myItem.moveYPosition(-intersectionRectangle.Height);
                        return;
                    }

                    else if (myRectangle.X < blockRectangle.X)
                    {
                        myItem.Reverse();
                    }
                    else if (myRectangle.X > blockRectangle.X)
                    {
                        myItem.Reverse();
                    }
                }
            }
        }
    }
}
