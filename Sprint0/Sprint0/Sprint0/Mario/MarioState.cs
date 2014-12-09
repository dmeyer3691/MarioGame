using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
	public class MarioState
	{
		//do not create a MarioState machine untill the sprites are initialized.        
		private SpriteEffects facing;
		private bool marioIsLarge;
		private bool marioHasFire;
		private bool marioHasStar;
        private Camera camera;
        private enum MarioStates { Standing, Jumping, Sliding, Walking, Crouching, Dead, ShootingFireball };
        private int starDrawCounter;
        private int starCounter;
		private MarioStates CurrentState;
		private ISprite CurrentSprite;
        private Mario myMario;
        private int hitCounter;
        private int itemCounter;
        private bool marioIsInvincible;
        private int invincibleCounter;

		public void Update()
		{
            if (marioHasStar)
            {
                starDrawCounter--;
                if (starDrawCounter < 0)
                {
                    starDrawCounter = Constants.blinkFramecount;
                }
            }
            if (IsHit())
            {
                starDrawCounter--;
                if (starDrawCounter < 0)
                {
                    starDrawCounter = Constants.blinkFramecount;
                }
                marioIsInvincible = true;
            }
            if (marioIsInvincible)
            {
                invincibleCounter++;
                if (invincibleCounter > Constants.invinciblityTimeout)
                {
                    marioIsInvincible = false;
                }
                if (starCounter > 0)
                {
                    starCounter--;
                    if (starCounter == 0)
                    {
                        marioIsInvincible = false;
                        EndStar();
                    }
                }
            }
            hitCounter++;
            if (GettingItem())
            {
                if (marioHasFire) FireFlowerTransition(itemCounter);
                else MushroomTransition(itemCounter);
            }
            itemCounter++;
			CurrentSprite.Update();
		}

		public void Draw(int x, int y)
		{
            if (starDrawCounter != Constants.blinkFramecount)
            {
                camera.Draw(CurrentSprite, x, y, facing);
            }
		}

		public MarioState(Mario mario, Camera cam)
		{
			//assume that we're starting in a small standing mario state untill the first command comes.
			CurrentSprite = new Sprites.MarioSmallStandingSprite();
			facing = SpriteEffects.None;
			marioIsLarge = false;
			marioHasFire = false;
			marioHasStar = false;
            marioIsInvincible = false;
            invincibleCounter = 0;
            myMario = mario;
			CurrentState = MarioStates.Standing;
            camera = cam;
            hitCounter = Constants.hitTimeout;
            itemCounter = Constants.itemTimeout;
            starDrawCounter = 0;
		}

        public bool IsHit()
        {
            return (hitCounter < Constants.hitTimeout);
        }

        
        public bool GettingItem()
        {
            return (itemCounter < Constants.itemTimeout);
        }
         
        public int GetWidth()
        {
            return CurrentSprite.GetWidth();
        }

        public int GetHeight()
        {
            return CurrentSprite.GetHeight();
        }

        public void Crouch()
        {
            if (CurrentState != MarioStates.Dead)
            {
                CurrentState = MarioStates.Crouching;
                if (marioHasFire)
                    CurrentSprite = new Sprites.MarioFireCrouchingSprite();
                else if (marioIsLarge)
                    CurrentSprite = new Sprites.MarioLargeCrouchingSprite();
            }
        }

		public void Stand()
		{
			if (CurrentState != MarioStates.Dead)
			{
                CurrentState = MarioStates.Standing;
				if (marioHasFire)
					CurrentSprite = new Sprites.MarioFireStandingSprite();
				else if (marioIsLarge)
					CurrentSprite = new Sprites.MarioLargeStandingSprite();
				else
					CurrentSprite = new Sprites.MarioSmallStandingSprite();
			}
		}

		public void Jump()
		{
			//because crouch jumping /is/ a thing, crouch overrides jump as far as displayed sprite.
			if (CurrentState != MarioStates.Dead && CurrentState != MarioStates.Crouching)
			{
                CurrentState = MarioStates.Jumping;
				if (marioHasFire)
					CurrentSprite = new Sprites.MarioFireJumpingSprite();
				else if (marioIsLarge)
					CurrentSprite = new Sprites.MarioLargeJumpingSprite();
				else
					CurrentSprite = new Sprites.MarioSmallJumpingSprite();
			}
		}

		public void Slide()
		{
			if (CurrentState != MarioStates.Dead)
			{
                CurrentState = MarioStates.Sliding;
				if (marioHasFire)
					CurrentSprite = new Sprites.MarioFireSlidingSprite();
				else if (marioIsLarge)
					CurrentSprite = new Sprites.MarioLargeSlidingSprite();
				else
					CurrentSprite = new Sprites.MarioSmallSlidingSprite();
			}
		}

		public void Walk()
		{
			if (CurrentState != MarioStates.Walking && CurrentState != MarioStates.Dead)
			{
				CurrentState = MarioStates.Walking;
                if (marioHasFire)
                    CurrentSprite = Sprites.SpriteFactory.MarioFireWalking;
                else if (marioIsLarge)
                    CurrentSprite = Sprites.SpriteFactory.MarioLargeWalking;
                else
                    CurrentSprite = Sprites.SpriteFactory.MarioSmallWalking;
			}
		}

        // Nothing currently calls this because we don't have a sprite that shows him throwing a fireball        
        public void ShootFireball()
        {
            if (CurrentState != MarioStates.Dead && marioHasFire)
            {
                CurrentState = MarioStates.ShootingFireball;
                CurrentSprite = new Sprites.MarioFireBallingSprite();
            }
        }

   		public void Dead()
		{
            if (!marioIsInvincible)
            {
                //dead overrides pretty much everything
                CurrentSprite = new Sprites.MarioDeadSprite();
                CurrentState = MarioStates.Dead;
            }
		}

		public void Hit()
		{
            if (!marioIsInvincible)
            {
                if (marioHasStar) return;
                if (!marioIsLarge)
                {
                    myMario.Dead();
                    return;
                }
                hitCounter = 0;
                if (marioHasFire)
                {
                    marioHasFire = false;
                }
                else
                {
                    marioIsLarge = false;
                }
                marioIsInvincible = true;
                reloadSprite();
            }
            
	    }

        public void Mushroom()
        {
            if (!marioIsLarge && CurrentState != MarioStates.Dead)
            {
                itemCounter = 0;
                marioIsLarge = true;
                reloadSprite();
            }
        }

        public void MushroomTransition(int count)
        {
            if ((count == 10) || (count == 40)) marioIsLarge = false;
            else if ((count == 20) || (count == 50)) marioIsLarge = true;
            reloadSprite();
        }

        public void Fireflower()
        {
            if (!marioHasFire && CurrentState != MarioStates.Dead)
            {
                itemCounter = 0;
                marioIsLarge = true;
                marioHasFire = true;
                reloadSprite();
            }
        }

        public void FireFlowerTransition(int count)
        {
            if ((count == 10) || (count == 40)) marioHasFire = false;
            else if ((count == 25) || (count == 50)) marioHasFire = true;
            reloadSprite();
            marioHasFire = true;
        }

        public void Left()
        {
            if (CurrentState != MarioStates.Jumping)
            {
                facing = SpriteEffects.FlipHorizontally;
            }
        }

        public void Right()
        {
            if (CurrentState != MarioStates.Jumping)
            {
                facing = SpriteEffects.None;
            }
        }

        public void Star()
        {
            marioHasStar = true;
            starDrawCounter = Constants.starTimeout;
            marioIsInvincible = true;
        }

        public bool IsInvincible()
        {
            return (marioHasStar | marioIsInvincible);
        }

        public bool IsDead()
        {
            return CurrentState == MarioStates.Dead;
        }

        public bool IsLarge()
        {
            return marioIsLarge;
        }

        public bool HasFire()
        {
            return marioHasFire;
        }

        public bool IsCrouching()
        {
            return CurrentState == MarioStates.Crouching;
        }

        public void EndStar()
        {
            marioHasStar = false;
            starDrawCounter = 0;
        }

        private void reloadSprite()
        {
	        switch (CurrentState)
	        {
		        case MarioStates.Crouching:
			        Crouch();
			        break;
		        case MarioStates.Dead:
			        Dead();
			        break;
		        case MarioStates.Jumping:
			        Jump();
			        break;
		        case MarioStates.ShootingFireball:
		            ShootFireball();
			        break;
    	        case MarioStates.Sliding:
			        Slide();
			        break;
		        case MarioStates.Standing:
			        Stand();
			        break;
		        case MarioStates.Walking:
			        CurrentState = MarioStates.Standing; //have to take it out of walking state to force a sprite reload.
			        Walk();
			        break;
	        }
        }
	}
}
