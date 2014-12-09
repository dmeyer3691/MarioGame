using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class FlagMario
    {
        private ISprite currentFrame;
        private int x;
        private int y;
        private enum flagMovementState {falling, walking, entering}
        public enum marioPowerupState { fire, small, big}
        private flagMovementState drawState;
        private marioPowerupState marioState;
        private Camera cam;
        
        public FlagMario(int x, int y, Camera c, marioPowerupState m)
        {
            this.x = x;
            this.y = y;
            cam = c;
            drawState = flagMovementState.falling;
            marioState = m;
            //in theory sprite should be the flagpole holding sprite, adding said sprite to our sprites is right now TODO.
            if (m == marioPowerupState.fire) currentFrame = new Sprites.MarioFireJumpingSprite();
            else if (m == marioPowerupState.big) currentFrame = new Sprites.MarioLargeJumpingSprite();
            else currentFrame = new Sprites.MarioSmallJumpingSprite();
        }

        public void Update() {
            if (drawState == flagMovementState.falling)
            {
                y++;
                if (y > Constants.bottomOfFlagpole)
                {
                    x += Constants.tileLength;
                    drawState = flagMovementState.walking;
                    if (marioState == marioPowerupState.small)
                    {
                        y += Constants.tileLength;
                        currentFrame = Sprites.SpriteFactory.MarioSmallWalking;
                    }
                    else if (marioState == marioPowerupState.big)
                    {
                        currentFrame = Sprites.SpriteFactory.MarioLargeWalking;
                    }
                    else
                    {
                        currentFrame = Sprites.SpriteFactory.MarioFireWalking;
                    }
                }
            }
            else if (drawState == flagMovementState.walking)
            {
                x++;
                if (x >= Constants.castleDoorPos)
                {
                    drawState = flagMovementState.entering;
                    if (marioState == marioPowerupState.small)
                    {
                        currentFrame = new Sprites.MarioSmallStandingSprite();
                    }
                    else if (marioState == marioPowerupState.big)
                    {
                        currentFrame = new Sprites.MarioLargeStandingSprite();
                    }
                    else
                    {
                        currentFrame = new Sprites.MarioFireStandingSprite();
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
