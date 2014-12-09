using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class MarioPhysics
    {

        private Mario myMario;
        private MarioState State;
        private double xVelocity;
        private double yVelocity;
        private bool running;
        private int jumpCount;
        public enum VerticalMovingDirection { Jumping, Falling, None };
        public VerticalMovingDirection verticalDirection {get; set;}
        public enum HorizontalMovingDirection { Left, Right, None };
        public HorizontalMovingDirection horizontalDirection { get; set; }
        private int bounceCounter;
        private bool hitCeiling;
        private bool hitGround;

        public MarioPhysics(Mario m, MarioState s)
        {
            myMario = m;
            State = s;
            xVelocity = 0;
            yVelocity = Constants.marioFallingSpeed;
            jumpCount = 0;
            verticalDirection = VerticalMovingDirection.Falling;
            horizontalDirection = HorizontalMovingDirection.None;
            bounceCounter = 0;
            hitCeiling = false;
            hitGround = true;
        }

        public void Update()
        {
            respondToEnemyKill();
            updateVertical();
            updateHorizontal();
        }

        private void updateHorizontal()
        {
            switch (horizontalDirection)
            {
                case HorizontalMovingDirection.Left:
                    if (running)
                    {
                        xVelocity = -Constants.marioRunningSpeed;
                    }
                    else
                    {
                        xVelocity = -Constants.marioWalkingSpeed;
                    }
                    break;
                case HorizontalMovingDirection.Right:
                    if (running)
                    {
                        xVelocity = Constants.marioRunningSpeed;
                    }
                    else
                    {
                        xVelocity = Constants.marioWalkingSpeed;
                    }
                    break;
                case HorizontalMovingDirection.None:
                    //no action
                    break;
            }

            myMario.setXPosition(myMario.getXPosition() + (int)(xVelocity));
            xVelocity *= Constants.velocityDecay;
        }

        private void updateVertical()
        {
            switch (verticalDirection)
            {
                case VerticalMovingDirection.Jumping:

                    jumpCount++;

                    if (jumpCount < Constants.jumpLimit)
                    {
                        yVelocity = -Constants.marioJumpingSpeed;
                    }

                    break;
                case VerticalMovingDirection.Falling:
                    jumpCount = 0;
                    yVelocity = Constants.marioFallingSpeed;
                    break;
                case VerticalMovingDirection.None:
                    jumpCount = Constants.jumpLimit;
                    break;
            }

            yVelocity++;
            myMario.setYPosition(myMario.getYPosition() + (int)(yVelocity));
            yVelocity *= Constants.velocityDecay;
        }

        private void respondToEnemyKill()
        {
            if (bounceCounter > 0)
            {
                if (bounceCounter == Constants.marioBounceLimit)
                {
                    verticalDirection = MarioPhysics.VerticalMovingDirection.Falling;
                }
                myMario.Jump();
                bounceCounter--;
                if (State.IsDead())
                {
                    yVelocity -= 1;
                }
                else
                {
                    yVelocity -= Constants.marioBounceDisplacement;
                }
            }
        }

        public void setRunning(bool state)
        {
            running = state;
        }

        public void resetBounceCounter()
        {
            bounceCounter = Constants.marioBounceLimit;
        }

        public void BoostJump()
        {
            bounceCounter = Constants.luigiBoostLimit;
        }

        public void setHitGround(bool hit)
        {
            hitGround = hit;
        }

        public bool getHitGround()
        {
            return hitGround;
        }

        public void setHitCeiling(bool hit)
        {
            hitCeiling = hit;
        }

        public int getXVelocity()
        {
            return (int) xVelocity;
        }

        public void Crouch()
        {
            verticalDirection = VerticalMovingDirection.Falling;
        }

        public void Jump()
        {
            if (!hitCeiling)
            {
                verticalDirection = VerticalMovingDirection.Jumping;
            }
        }

        public void Left()
        {
            horizontalDirection = HorizontalMovingDirection.Left;
        }

        public void Right()
        {
            horizontalDirection = HorizontalMovingDirection.Right;
        }

        public void Stand()
        {
            if (hitGround)
            {
                State.Stand();
                verticalDirection = VerticalMovingDirection.Falling;
            }
            else
            {
                verticalDirection = VerticalMovingDirection.None;
            }
            horizontalDirection = HorizontalMovingDirection.None;
            if ( (int)xVelocity != 0)
            {
                State.Slide();
            }
        }
    }
}
