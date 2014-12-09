using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi
{
    public class Achievements
    {
        private bool firstGoomba;
        private bool firstKoopa;
        private bool coinGet;
        private bool mushroomGet;
        private bool flowerGet;
        private bool starGet;
        private bool fireKill;
        private int displayTime;
        private enum AchievementDisplays { none, goombaKill, koopaKill, coin, mushroom, flower, star, fire, end };
        private AchievementDisplays displayed;


        public Achievements()
        {
            firstGoomba = false;
            firstKoopa = false;
            mushroomGet = false;
            flowerGet = false;
            starGet = false;
            fireKill = false;
            displayTime = 0;
            displayed = AchievementDisplays.none;
        }

        public void Draw(SpriteBatch batch, SpriteFont font)
        {
            if (displayTime > 0)
            {
                displayTime--;
                switch (displayed)
                {
                    case AchievementDisplays.goombaKill:
                        batch.DrawString(font, "ACHIEVEMENT: Kill a Goomba!", new Vector2(10, 45), Color.White);
                        break;
                    case AchievementDisplays.koopaKill:
                        batch.DrawString(font, "ACHIEVEMENT: Kill a Koopa!", new Vector2(10, 45), Color.White);
                        break;
                    case AchievementDisplays.coin:
                        batch.DrawString(font, "ACHIEVEMENT: Get a Coin!", new Vector2(10, 45), Color.White);
                        break;
                    case AchievementDisplays.mushroom:
                        batch.DrawString(font, "ACHIEVEMENT: Get a Mushroom!", new Vector2(10, 45), Color.White);
                        break;
                    case AchievementDisplays.flower:
                        batch.DrawString(font, "ACHIEVEMENT: Get a FireFlower!", new Vector2(10, 45), Color.White);
                        break;
                    case AchievementDisplays.star:
                        batch.DrawString(font, "ACHIEVEMENT: Get Star Power!", new Vector2(10, 45), Color.White);
                        break;
                    case AchievementDisplays.fire:
                        batch.DrawString(font, "ACHIEVEMENT: Kill it with fire!", new Vector2(10, 45), Color.White);
                        break;
                    case AchievementDisplays.end:
                        batch.DrawString(font, "ACHIEVEMENT: Finish level 1-1!", new Vector2(10, 45), Color.White);
                        break;
                    default:
                        //do nothing
                        break;
                }
            }
            else
            {
                displayed = AchievementDisplays.none;
            }
        }

        public void GoombaKill()
        {
            if (!firstGoomba)
            {
                displayTime = 100;
                displayed = AchievementDisplays.goombaKill;
            }
            firstGoomba = true;
        }

        public void KoopaKill()
        {
            if (!firstKoopa)
            {
                displayTime = 100;
                displayed = AchievementDisplays.koopaKill;
            }
            firstKoopa = true;
        }

        public void CoinGet()
        {
            if (!coinGet)
            {
                displayTime = 100;
                displayed = AchievementDisplays.coin;
            }
            coinGet = true;
        }

        public void MushroomGet()
        {
            if (!mushroomGet)
            {
                displayTime = 100;
                displayed = AchievementDisplays.mushroom;
            }
            mushroomGet = true;
        }

        public void FlowerGet()
        {
            if (!flowerGet)
            {
                displayTime = 100;
                displayed = AchievementDisplays.flower;
            }
            flowerGet = true;
        }

        public void StarGet()
        {
            if (!starGet)
            {
                displayTime = 100;
                displayed = AchievementDisplays.star;
            }
            starGet = true;
        }

        public void FireKill()
        {
            if (!fireKill)
            {
                displayTime = 100;
                displayed = AchievementDisplays.fire;
            }
            fireKill = true;
        }

        public void Ending()
        {
            displayTime = 100;
            displayed = AchievementDisplays.end;
        }
    }
}
