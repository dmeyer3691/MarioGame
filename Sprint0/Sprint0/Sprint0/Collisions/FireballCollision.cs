using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TeamYoshi.Collisions
{      
    public class FireballCollision
    {
        private Fireball fireball;

        public FireballCollision(Fireball fb)
        {
            fireball = fb;
        }

        // when a ball hits an enemy both are destroyed
        public bool FireballEnemyCollisionTest(IList<IEnemy> enemies)
        {
            Rectangle fbRectangle = fireball.GetRectangle();
            Rectangle enemyRectangle;
            Rectangle intersectionRectangle;

            Queue<IEnemy> doomedEnemies = new Queue<IEnemy>();

            foreach (IEnemy enemy in enemies)
            {
                enemyRectangle = enemy.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(fbRectangle, enemyRectangle);

                if (!intersectionRectangle.IsEmpty)
                {
                    // hud score method needed
                    doomedEnemies.Enqueue(enemy);
                }
            }

            while (doomedEnemies.Count() > 0)
            {
                IEnemy e = doomedEnemies.Dequeue();
                enemies.Remove(e);
                return true;
            }
            return false;
        }

        // when a ball hits a block from above it deflects up
        // when it hits a block from below it deflects down
        // when it hits on the side it is destroyed
        public bool FireballBlockCollisionTest(IList<IBlock> blocks)
        {
            Rectangle fbRectangle = fireball.GetRectangle();
            Rectangle blockRectangle;
            Rectangle intersectionRectangle;
            
            foreach (IBlock block in blocks)
            {
                blockRectangle = block.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(fbRectangle, blockRectangle);

                if (!intersectionRectangle.IsEmpty)
                {
                    if (intersectionRectangle.Width >= intersectionRectangle.Height)
                    {
                        fireball.Reverse();
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}
