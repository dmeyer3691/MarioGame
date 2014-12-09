using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Collisions
{
    public class LuigiBlockCollision
    {

        private Luigi myLuigi;

        public LuigiBlockCollision(Luigi luigi)
        {
            myLuigi = luigi;
        }

        public Tuple<int, int, bool, bool> BlockCollisionTest(SoundEffects sound, HUD hud, IList<IBlock> blocks, int x, int y, IList<IItem> items, Camera c)
        {
            Rectangle luigiRectangle = myLuigi.GetRectangle();
            Rectangle blockRectangle;
            Rectangle intersectionRectangle;
            bool hitGround = false;
            bool hitCeiling = false;
            Tuple<int, int, bool, bool> result;
            foreach (IBlock block in blocks)
            {
                blockRectangle = block.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(luigiRectangle, blockRectangle);
                if (!intersectionRectangle.IsEmpty)
                {
                    if ((intersectionRectangle.Width >= intersectionRectangle.Height))
                    {
                        if (luigiRectangle.Y > blockRectangle.Y)
                        {
                            block.Hit(items, false, myLuigi.IsLarge(), hud, sound);
                            hitCeiling = true;
                            y += (intersectionRectangle.Height);
                            luigiRectangle.Y += intersectionRectangle.Height;
                        }
                        else
                        {
                            hitGround = true;
                            if (block is Blocks.VerticalWarpPipe)
                            {
                                if (myLuigi.IsCrouching())
                                {
                                    c.SetXPos(Constants.verticalWarp.Item1-Constants.tileLength);
                                    x = Constants.verticalWarp.Item1;
                                    y = Constants.verticalWarp.Item2;
                                    break;
                                }
                            }
                            y -= (intersectionRectangle.Height);
                            luigiRectangle.Y -= intersectionRectangle.Height;
                        }
                    }
                    else
                    {
                        if (luigiRectangle.X > blockRectangle.X)
                        {
                            x += (intersectionRectangle.Width);
                            luigiRectangle.X += intersectionRectangle.X;
                        }
                        else
                        {
                            x -= (intersectionRectangle.Width);
                            luigiRectangle.X -= intersectionRectangle.X;
                            if (block is Blocks.HorizontalWarpPipe)
                            {
                                c.SetXPos(Constants.horizontalWarp.Item1-Constants.tileLength);
                                x = Constants.horizontalWarp.Item1;
                                y = Constants.horizontalWarp.Item2;                                
                                break;
                            }
                        }
                    }
                }
            }
            result = new Tuple<int, int, bool, bool>(x, y, hitCeiling, hitGround);
            return result;
        }

    }
}
