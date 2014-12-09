using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Items
{
    public class Fireflower : IItem
    {
        private ISprite FireflowerSprite = new Sprites.FireflowerSprite();
        private int xPosition;
        private int yPosition;
        private Camera camera;

        public Fireflower(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
        }

        public void Reverse()
        {

        }

        public void Draw()
        {
            camera.Draw(FireflowerSprite, xPosition, yPosition);
        }

        public String GetItemName()
        {
            return "Fireflower";
        }

        public void Update(IList<IBlock> blocks)
        {

        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, FireflowerSprite.GetWidth(), FireflowerSprite.GetHeight());
        }
        public void moveYPosition(int offset)
        {
            yPosition += offset;
        }
        public bool DestroyItem() { return false; }
    }
}
