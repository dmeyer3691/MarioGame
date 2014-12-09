using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi
{
    public class Fireball : IProjectile
    {
        Collisions.FireballCollision fbCollision;
        
        private ISprite FireballSprite = new Sprites.FireballSprite();
        private int xPosition;
        private int yPosition;
        private bool isDestroyed = false;
        private int vertVelocity;
        Camera camera;

        public Fireball(int x, int y, Camera cam)
        {
            camera = cam;
            xPosition = x;
            yPosition = y;

            vertVelocity = 1;

            fbCollision = new Collisions.FireballCollision(this);
        }

        public void Draw()
        {
            camera.Draw(FireballSprite, xPosition, yPosition);
        }

        public void Update(IList<IBlock> blocks, IList<IEnemy> enemies)
        {
            if (fbCollision.FireballEnemyCollisionTest(enemies))
            {
                isDestroyed = true;
                //this.DestroyProjectile();
            }

            if (fbCollision.FireballBlockCollisionTest(blocks))
            {
                isDestroyed = true;
                //this.DestroyProjectile();
            }
            // motion
            // need some way to tell which way mario is facing
            this.xPosition++;
            this.yPosition += vertVelocity;

            FireballSprite.Update();
        }

        public bool DestroyProjectile()
        {
            return isDestroyed;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, FireballSprite.GetWidth(), FireballSprite.GetHeight());
        }

        public void Reverse()
        {
            vertVelocity *= -1;
        }

    }
}
