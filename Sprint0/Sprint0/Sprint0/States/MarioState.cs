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
		private enum MarioStates
		{
			Standing, Jumping, Sliding, Walking, Crouching, Dead, shootingFireball
		}
        private int starDrawCounter;
		private MarioStates CurrentState;
		private ISprite CurrentSprite;
        private Mario myMario;
        private int hitCounter;
        private int hitLimit;
        private bool marioIsInvincible;
        private int invincibleCounter;
        private int invincibleLimit;

		public void Update()
		{
            if (marioHasStar)
            {
                starDrawCounter--;
                if (starDrawCounter < 0)
                {
                    starDrawCounter = 5;
                }
            }
            if (marioIsInvincible)
            {
                invincibleCounter++;
                if (invincibleCounter > invincibleLimit)
                {
                    marioIsInvincible = false;
                }
            }
            hitCounter++;
			CurrentSprite.Update();
		}
		public void Draw(int x, int y)
		{
            if (starDrawCounter != 5)
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
            invincibleLimit = 25;
            myMario = mario;
			CurrentState = MarioStates.Standing;
            camera = cam;
            hitLimit = 25;
            hitCounter = hitLimit;
		}

        public bool IsHit()
        {
            return (hitCounter < hitLimit);
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
        public void ShootFireball()
        {
            if (CurrentState != MarioStates.Dead && marioHasFire)
            {
                CurrentState = MarioStates.shootingFireball;
                CurrentSprite = new Sprites.MarioFireBallingSprite();
                Fireball fireball = new Fireball(myMario.xPosition, myMario.yPosition, camera);
                fireball.shoot();
            }
        }

		public void Dead()
		{
			//dead overrides pretty much everything
			CurrentSprite = new Sprites.MarioDeadSprite();
			CurrentState = MarioStates.Dead;
		}
		public void Hit()
		{
            hitCounter = 0;

			if (marioHasStar) return;
			if (!marioIsLarge)
			{
                Dead();
				return;
			}
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
        public void Mushroom()
        {
            if (!marioIsLarge && CurrentState != MarioStates.Dead)
            {
                marioIsLarge = true;
                reloadSprite();
            }
        }

        public void Fireflower()
        {
            if (!marioHasFire && CurrentState != MarioStates.Dead)
            {
                marioIsLarge = true;
                marioHasFire = true;
                reloadSprite();
            }
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
            starDrawCounter = 5;
        }

        public bool IsInvinsible()
        {
            return marioHasStar;
        }

        public bool IsDead()
        {
            return CurrentState == MarioStates.Dead;
        }
        public bool IsLarge()
        {
            return marioIsLarge;
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
		        case MarioStates.shootingFireball:
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
