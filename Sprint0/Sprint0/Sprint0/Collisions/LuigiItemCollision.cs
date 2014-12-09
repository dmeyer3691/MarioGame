using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Collisions
{
    public class LuigiItemCollision
    {

        private Luigi myLuigi;

        public LuigiItemCollision(Luigi luigi)
        {
            myLuigi = luigi;
        }

        public void ItemCollisionTest(SoundEffects sound, HUD hud, IList<IItem> items)
        {
            Rectangle luigiRectangle = myLuigi.GetRectangle();
            Rectangle itemRectangle;
            Rectangle intersectionRectangle;
            Queue<IItem> doomedItems = new Queue<IItem>();
            foreach (IItem item in items)
            {
                itemRectangle = item.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(luigiRectangle, itemRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    // todo
                    switch (item.GetItemName())
                    {
                        case "Coin":
                            //myLuigi.Coin();
                            hud.addCoinLuigi();
                            hud.increaseScoreLuigi(Constants.coinValue);
                            hud.achievements.CoinGet();
                            break;
                        case "Mushroom":
                            sound.Powerup();
                            myLuigi.Mushroom();
                            hud.increaseScoreLuigi(Constants.mushroomValue);
                            hud.achievements.MushroomGet();
                            break;
                        case "Fireflower":
                            sound.Powerup();
                            myLuigi.Fireflower();
                            hud.increaseScoreLuigi(Constants.fireflowerValue);
                            hud.achievements.FlowerGet();
                            break;
                        case "Oneup":
                            sound.OneUp();
                            hud.extraLifeLuigi();
                            hud.increaseScoreLuigi(Constants.oneUpValue);
                            break;
                        case "Star":
                            sound.Powerup();
                            myLuigi.Star();
                            hud.increaseScoreLuigi(Constants.starValue);
                            hud.achievements.StarGet();
                            break;
                        default:
                            // nothing
                            break;
                    }
                    doomedItems.Enqueue(item);


                }
            }
            while (doomedItems.Count() > 0)
            {
                IItem item = doomedItems.Dequeue();
                items.Remove(item);


            }
        }

    }
}
