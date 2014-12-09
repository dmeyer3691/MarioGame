using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Collisions
{
    public class MarioItemCollision
    {

        private Mario myMario;

        public MarioItemCollision(Mario mario)
        {
            myMario = mario;
        }

        public void ItemCollisionTest(SoundEffects sound, HUD hud, IList<IItem> items)
        {
            Rectangle marioRectangle = myMario.GetRectangle();
            Rectangle itemRectangle;
            Rectangle intersectionRectangle;
            Queue<IItem> doomedItems = new Queue<IItem>();
            foreach (IItem item in items)
            {
                itemRectangle = item.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(marioRectangle, itemRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    // todo
                    switch (item.GetItemName())
                    {
                        case "Coin":
                            //myMario.Coin();
                            hud.addCoinMario();
                            hud.increaseScoreMario(Constants.coinValue);
                            hud.achievements.CoinGet();
                            break;
                        case "Mushroom":
                            sound.Powerup();
                            myMario.Mushroom();
                            hud.increaseScoreMario(Constants.mushroomValue);
                            hud.achievements.MushroomGet();
                            break;
                        case "Fireflower":
                            sound.Powerup();
                            myMario.Fireflower();
                            hud.increaseScoreMario(Constants.fireflowerValue);
                            hud.achievements.FlowerGet();
                            break;
                        case "Oneup":
                            sound.OneUp();
                            hud.extraLifeMario();
                            hud.increaseScoreMario(Constants.oneUpValue);
                            break;
                        case "Star":
                            sound.Powerup();
                            myMario.Star();
                            hud.increaseScoreMario(Constants.starValue);
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
