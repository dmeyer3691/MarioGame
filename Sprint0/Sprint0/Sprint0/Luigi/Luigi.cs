using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamYoshi.Collisions;

namespace TeamYoshi
{
    public class Luigi : IPlayer
    {
        private int xPosition;
        private int yPosition;
        private LuigiState State;
        private LuigiItemCollision itemCollision;
        private LuigiEnemyCollision enemyCollision;
        private LuigiBlockCollision blockCollision;
        private IList<IProjectile> projectileList;
        private Camera camera;
        private LuigiPhysics Physics;
        private SoundEffects sound;
        private bool enemyKillSequence;
        private bool enemyKilled;


        // constructor
        public Luigi(int x, int y, Camera cam, SoundEffects s, IList<IProjectile> projectiles)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;
            State = new LuigiState(this, cam);
            Physics = new LuigiPhysics(this, State);
            itemCollision = new LuigiItemCollision(this);
            enemyCollision = new LuigiEnemyCollision(this);
            blockCollision = new LuigiBlockCollision(this);
            sound = s;
            enemyKillSequence = false;
            enemyKilled = false;
            projectileList = projectiles;
        }


        public void Update()
        {
            State.Update();
            if (!GettingItem()) Physics.Update();
            //if luigi is beyond the camera horizon, clip
            if (xPosition < camera.CameraPos()) xPosition = camera.CameraPos();
            if (Physics.getHitGround()) enemyKillSequence = false;

        }

        public void Draw()
        {
            State.Draw(xPosition, yPosition);
            /*
            foreach (IProjectile p in projectileList)
            {
                p.Draw();
            }
             */
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, State.GetWidth(), State.GetHeight());
        }

        public bool killedEnemy()
        {
            return enemyKilled;
        }

        public bool isInKillSequence()
        {
            return enemyKillSequence;
        }

        public int getXPosition()
        {
            return xPosition;
        }

        public int getYPosition()
        {
            return yPosition;
        }

        public void setXPosition(int x)
        {
            xPosition = x;
        }

        public void setYPosition(int y)
        {
            yPosition = y;
        }

        //Collision Tests
        public void BlockCollisionTest(HUD hud, IList<IBlock> blocks, IList<IItem> items)
        {
            Tuple<int, int, bool, bool> result = blockCollision.BlockCollisionTest(sound, hud, blocks, xPosition, yPosition, items, camera);
            xPosition = result.Item1;
            yPosition = result.Item2;
            Physics.setHitCeiling(result.Item3);
            Physics.setHitGround(result.Item4);
        }

        public void ItemCollisionTest(HUD hud, IList<IItem> items)
        {
            itemCollision.ItemCollisionTest(sound, hud, items);
        }

        public void EnemyCollisionTest(HUD hud, IList<IEnemy> enemies)
        {
            Tuple<int, bool> result = enemyCollision.EnemyCollisionTest(this, hud, enemies, xPosition, sound);
            xPosition = result.Item1;
            enemyKilled = result.Item2;
            if (enemyKilled)
            {
                Physics.resetBounceCounter();
                enemyKillSequence = true;
            }
        }

        // Extending LuigiSprite methods
        public void Crouch()
        {
            State.Crouch();
            Physics.Crouch();
        }

        public void Stand()
        {
            Physics.Stand();
        }

        public void Jump()
        {
            sound.JumpSmall();
            State.Jump();
            Physics.Jump();
        }

        public void BoostJump()
        {
            Physics.BoostJump();
        }

        public void Walk()
        {
            Physics.setRunning(false);
            State.Walk();
        }

        public void Dead()
        {
            sound.StopTheme();
            sound.LuigiDie();
            State.Dead();
            Physics.resetBounceCounter();
        }

        public void Hit()
        {
            State.Hit();
        }

        public bool Invincible()
        {
            return State.IsInvincible();
        }

        public void Mushroom() 
        {
            State.Mushroom();
        }

        public void Fireflower()
        {
            State.Fireflower();
        }

        public void Left()
        {
            State.Left();
            Physics.Left();
            Walk();
        }

        public void Right()
        {
            State.Right();
            Physics.Right();
            Walk();
        }

        public void Run()
        {
            Physics.setRunning(true);
        }

        public void Fireball()
        {
            if (this.HasFire())
            {
                Fireball fb = new Fireball(xPosition, yPosition, camera);
                // fb.Draw();
                //projectileList.Add(fb);
                
                sound.Fireball();
            }
        }

        public void Star()
        {
            State.Star();
        }

        public bool IsDead()
        {
            return State.IsDead();
        }
        public bool IsHit()
        {
            return State.IsHit();
        }
        public bool GettingItem()
        {
            return State.GettingItem();
        }
        public bool IsLarge()
        {
            return State.IsLarge();
        }
        public bool IsCrouching()
        {
            return State.IsCrouching();
        }
        public bool HasFire()
        {
            return State.HasFire();
        }
    }
}
