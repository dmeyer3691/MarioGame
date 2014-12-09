using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Items
{
    public class Coin : IItem
    {

        private ISprite CoinSprite = new Sprites.CoinSprite();
        private int xPosition;
        private int yPosition;
        private int duration;
        private bool destroy;
        Camera camera;
        public Coin(int x, int y, Camera cam)
        {
            destroy = false;
            duration = 0;
            camera = cam;
            xPosition = x;
            yPosition = y;
        }
        
        public void Reverse()
        {
        }

        public void Draw()
        {
            camera.Draw(CoinSprite, xPosition, yPosition);
        }

        public String GetItemName()
        {
            return "Coin";
        }

        public void Update(IList<IBlock> blocks)
        {
            if (duration <= 6)
            {
                yPosition = yPosition - 5;
                duration++;
                CoinSprite.Update();
            }
            else if (duration <= 12)
            {
                yPosition = yPosition + 5;
                duration++;
                CoinSprite.Update();
            }
            else
            {
                destroy = true;
            }


            
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, CoinSprite.GetWidth(), CoinSprite.GetHeight());
        }
        public void moveYPosition(int offset)
        {
            yPosition += offset;
        }

        public bool DestroyItem() { return destroy; }

    }
}
