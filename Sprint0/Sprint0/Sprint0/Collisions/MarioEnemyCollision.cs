using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Collisions
{
    public class MarioEnemyCollision
    {

        private Mario myMario;

        public MarioEnemyCollision(Mario mario)
        {
            myMario = mario;
        }

        public Tuple<int, bool> EnemyCollisionTest(Mario mario, HUD hud, IList<IEnemy> enemies, int x, SoundEffects sound)
        {
            Rectangle marioRectangle = myMario.GetRectangle();
            Rectangle enemyRectangle;
            bool enemyKilled = false;
            bool invincible = myMario.Invincible();
            int xpos = x;
            Rectangle intersectionRectangle;
            Queue<IEnemy> doomedEnemies = new Queue<IEnemy>();

            foreach (IEnemy enemy in enemies)
            {

                enemyRectangle = enemy.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(marioRectangle, enemyRectangle);

                if (!intersectionRectangle.IsEmpty)
                {
                    

                    if (intersectionRectangle.Width >= intersectionRectangle.Height)
                    {
                        sound.Bump();
                        doomedEnemies.Enqueue(enemy);
                        hud.marioEnemyKill(mario);
                        enemyKilled = true;
                    }
                    else if (invincible)
                    {
                        doomedEnemies.Enqueue(enemy);
                    }
                    else
                    {
                        myMario.Hit();
                        if (marioRectangle.X < enemyRectangle.X)
                        {
                            xpos = xpos - intersectionRectangle.Width;
                        }
                        else
                        {
                            xpos = xpos + intersectionRectangle.Width;

                        }
                        if (myMario.IsDead())
                        {
                            hud.lifeLostMario();
                        }
                    }

                }
            }
            
            while (doomedEnemies.Count() > 0)
            {
                IEnemy enemie = doomedEnemies.Dequeue();
                enemies.Remove(enemie);
            }

            return new Tuple<int,bool>(xpos, enemyKilled);
        }
    }
}
