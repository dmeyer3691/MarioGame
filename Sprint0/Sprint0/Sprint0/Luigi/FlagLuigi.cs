using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class FlagLuigi
    {
        private ISprite currentFrame;
        private int x;
        private int y;
        private enum flagMovementState {falling, walking, entering}
        public enum luigiPowerupState { fire, small, big}
        private flagMovementState drawState;
        private luigiPowerupState luigiState;
        private Camera cam;
        
        public FlagLuigi(int x, int y, Camera c, luigiPowerupState m)
        {
            this.x = x;
            this.y = y;
            cam = c;
            drawState = flagMovementState.falling;
            luigiState = m;
            //in theory sprite should be the flagpole holding sprite, adding said sprite to our sprites is right now TODO.
            if (m == luigiPowerupState.fire) currentFrame = new Sprites.LuigiFireJumpingSprite();
            else if (m == luigiPowerupState.big) currentFrame = new Sprites.LuigiLargeJumpingSprite();
            else currentFrame = new Sprites.LuigiSmallJumpingSprite();
        }

        public void Update() {
            if (drawState == flagMovementState.falling)
            {
                y++;
                if (y > Constants.bottomOfFlagpole)
                {
                    x += Constants.tileLength;
                    drawState = flagMovementState.walking;
                    if (luigiState == luigiPowerupState.small)
                    {
                        y += Constants.tileLength;
                        currentFrame = Sprites.SpriteFactory.LuigiSmallWalking;
                    }
                    else if (luigiState == luigiPowerupState.big)
                    {
                        currentFrame = Sprites.SpriteFactory.LuigiLargeWalking;
                    }
                    else
                    {
                        currentFrame = Sprites.SpriteFactory.LuigiFireWalking;
                    }
                }
            }
            else if (drawState == flagMovementState.walking)
            {
                x++;
                if (x >= Constants.castleDoorPos)
                {
                    drawState = flagMovementState.entering;
                    if (luigiState == luigiPowerupState.small)
                    {
                        currentFrame = new Sprites.LuigiSmallStandingSprite();
                    }
                    else if (luigiState == luigiPowerupState.big)
                    {
                        currentFrame = new Sprites.LuigiLargeStandingSprite();
                    }
                    else
                    {
                        currentFrame = new Sprites.LuigiFireStandingSprite();
                    }
                }
            }
            else
            {
                //goto next level in theory. goto menu?
            }
        }
        public void Draw()
        {
            cam.Draw(currentFrame,x,y);
        }
    }
}
