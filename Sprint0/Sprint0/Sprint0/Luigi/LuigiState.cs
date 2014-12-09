using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
	public class LuigiState
	{
		//do not create a LuigiState machine untill the sprites are initialized.        
		private SpriteEffects facing;
		private bool luigiIsLarge;
		private bool luigiHasFire;
		private bool luigiHasStar;
        private Camera camera;
        private enum LuigiStates { Standing, Jumping, Sliding, Walking, Crouching, Dead, ShootingFireball };
        private int starDrawCounter;
        private int starCounter;
		private LuigiStates CurrentState;
		private ISprite CurrentSprite;
        private Luigi myLuigi;
        private int hitCounter;
        private int itemCounter;
        private bool luigiIsInvincible;
        private int invincibleCounter;

		public void Update()
		{
            if (luigiHasStar)
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
                luigiIsInvincible = true;
            }
            if (luigiIsInvincible)
            {
                invincibleCounter++;
                if (invincibleCounter > Constants.invinciblityTimeout)
                {
                    luigiIsInvincible = false;
                }
                if (starCounter > 0)
                {
                    starCounter--;
                    if (starCounter == 0)
                    {
                        luigiIsInvincible = false;
                        EndStar();
                    }
                }
            }
            hitCounter++;
            if (GettingItem())
            {
                if (luigiHasFire) FireFlowerTransition(itemCounter);
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

		public LuigiState(Luigi luigi, Camera cam)
		{
			//assume that we're starting in a small standing luigi state untill the first command comes.
			CurrentSprite = new Sprites.LuigiSmallStandingSprite();
			facing = SpriteEffects.None;
			luigiIsLarge = false;
			luigiHasFire = false;
			luigiHasStar = false;
            luigiIsInvincible = false;
            invincibleCounter = 0;
            myLuigi = luigi;
			CurrentState = LuigiStates.Standing;
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
            if (CurrentState != LuigiStates.Dead)
            {
                CurrentState = LuigiStates.Crouching;
                if (luigiHasFire)
                    CurrentSprite = new Sprites.LuigiFireCrouchingSprite();
                else if (luigiIsLarge)
                    CurrentSprite = new Sprites.LuigiLargeCrouchingSprite();
            }
        }

		public void Stand()
		{
			if (CurrentState != LuigiStates.Dead)
			{
                CurrentState = LuigiStates.Standing;
				if (luigiHasFire)
					CurrentSprite = new Sprites.LuigiFireStandingSprite();
				else if (luigiIsLarge)
					CurrentSprite = new Sprites.LuigiLargeStandingSprite();
				else
					CurrentSprite = new Sprites.LuigiSmallStandingSprite();
			}
		}

		public void Jump()
		{
			//because crouch jumping /is/ a thing, crouch overrides jump as far as displayed sprite.
			if (CurrentState != LuigiStates.Dead && CurrentState != LuigiStates.Crouching)
			{
                CurrentState = LuigiStates.Jumping;
				if (luigiHasFire)
					CurrentSprite = new Sprites.LuigiFireJumpingSprite();
				else if (luigiIsLarge)
					CurrentSprite = new Sprites.LuigiLargeJumpingSprite();
				else
					CurrentSprite = new Sprites.LuigiSmallJumpingSprite();
			}
		}

		public void Slide()
		{
			if (CurrentState != LuigiStates.Dead)
			{
                CurrentState = LuigiStates.Sliding;
				if (luigiHasFire)
					CurrentSprite = new Sprites.LuigiFireSlidingSprite();
				else if (luigiIsLarge)
					CurrentSprite = new Sprites.LuigiLargeSlidingSprite();
				else
					CurrentSprite = new Sprites.LuigiSmallSlidingSprite();
			}
		}

		public void Walk()
		{
			if (CurrentState != LuigiStates.Walking && CurrentState != LuigiStates.Dead)
			{
				CurrentState = LuigiStates.Walking;
                if (luigiHasFire)
                    CurrentSprite = Sprites.SpriteFactory.LuigiFireWalking;
                else if (luigiIsLarge)
                    CurrentSprite = Sprites.SpriteFactory.LuigiLargeWalking;
                else
                    CurrentSprite = Sprites.SpriteFactory.LuigiSmallWalking;
			}
		}

        // Nothing currently calls this because we don't have a sprite that shows him throwing a fireball        
        public void ShootFireball()
        {
            if (CurrentState != LuigiStates.Dead && luigiHasFire)
            {
                CurrentState = LuigiStates.ShootingFireball;
                CurrentSprite = new Sprites.LuigiFireBallingSprite();
            }
        }

   		public void Dead()
		{
            if (!luigiIsInvincible)
            {
                //dead overrides pretty much everything
                CurrentSprite = new Sprites.LuigiDeadSprite();
                CurrentState = LuigiStates.Dead;
            }
		}

		public void Hit()
		{
            if (!luigiIsInvincible)
            {
                if (luigiHasStar) return;
                if (!luigiIsLarge)
                {
                    myLuigi.Dead();
                    return;
                }
                hitCounter = 0;
                if (luigiHasFire)
                {
                    luigiHasFire = false;
                }
                else
                {
                    luigiIsLarge = false;
                }
                luigiIsInvincible = true;
                reloadSprite();
            }
            
	    }

        public void Mushroom()
        {
            if (!luigiIsLarge && CurrentState != LuigiStates.Dead)
            {
                itemCounter = 0;
                luigiIsLarge = true;
                reloadSprite();
            }
        }

        public void MushroomTransition(int count)
        {
            if ((count == 10) || (count == 40)) luigiIsLarge = false;
            else if ((count == 20) || (count == 50)) luigiIsLarge = true;
            reloadSprite();
        }

        public void Fireflower()
        {
            if (!luigiHasFire && CurrentState != LuigiStates.Dead)
            {
                itemCounter = 0;
                luigiIsLarge = true;
                luigiHasFire = true;
                reloadSprite();
            }
        }

        public void FireFlowerTransition(int count)
        {
            if ((count == 10) || (count == 40)) luigiHasFire = false;
            else if ((count == 25) || (count == 50)) luigiHasFire = true;
            reloadSprite();
            luigiHasFire = true;
        }

        public void Left()
        {
            if (CurrentState != LuigiStates.Jumping)
            {
                facing = SpriteEffects.FlipHorizontally;
            }
        }

        public void Right()
        {
            if (CurrentState != LuigiStates.Jumping)
            {
                facing = SpriteEffects.None;
            }
        }

        public void Star()
        {
            luigiHasStar = true;
            starDrawCounter = Constants.starTimeout;
            luigiIsInvincible = true;
        }

        public bool IsInvincible()
        {
            return (luigiHasStar | luigiIsInvincible);
        }

        public bool IsDead()
        {
            return CurrentState == LuigiStates.Dead;
        }

        public bool IsLarge()
        {
            return luigiIsLarge;
        }

        public bool HasFire()
        {
            return luigiHasFire;
        }

        public bool IsCrouching()
        {
            return CurrentState == LuigiStates.Crouching;
        }

        public void EndStar()
        {
            luigiHasStar = false;
            starDrawCounter = 0;
        }

        private void reloadSprite()
        {
	        switch (CurrentState)
	        {
		        case LuigiStates.Crouching:
			        Crouch();
			        break;
		        case LuigiStates.Dead:
			        Dead();
			        break;
		        case LuigiStates.Jumping:
			        Jump();
			        break;
		        case LuigiStates.ShootingFireball:
		            ShootFireball();
			        break;
    	        case LuigiStates.Sliding:
			        Slide();
			        break;
		        case LuigiStates.Standing:
			        Stand();
			        break;
		        case LuigiStates.Walking:
			        CurrentState = LuigiStates.Standing; //have to take it out of walking state to force a sprite reload.
			        Walk();
			        break;
	        }
        }
	}
}
