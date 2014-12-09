using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Collisions
{
    public class LuigiEnemyCollision
    {

        private Luigi myLuigi;

        public LuigiEnemyCollision(Luigi luigi)
        {
            myLuigi = luigi;
        }

        public Tuple<int, bool> EnemyCollisionTest(Luigi luigi, HUD hud, IList<IEnemy> enemies, int x, SoundEffects sound)
        {
            Rectangle luigiRectangle = myLuigi.GetRectangle();
            Rectangle enemyRectangle;
            bool enemyKilled = false;
            bool invincible = myLuigi.Invincible();
            int xpos = x;
            Rectangle intersectionRectangle;
            Queue<IEnemy> doomedEnemies = new Queue<IEnemy>();

            foreach (IEnemy enemy in enemies)
            {

                enemyRectangle = enemy.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(luigiRectangle, enemyRectangle);

                if (!intersectionRectangle.IsEmpty)
                {
                    

                    if (intersectionRectangle.Width >= intersectionRectangle.Height)
                    {
                        sound.Bump();
                        doomedEnemies.Enqueue(enemy);
                        hud.luigiEnemyKill(luigi);
                        enemyKilled = true;
                    }
                    else if (invincible)
                    {
                        doomedEnemies.Enqueue(enemy);
                    }
                    else
                    {
                        myLuigi.Hit();
                        if (luigiRectangle.X < enemyRectangle.X)
                        {
                            xpos = xpos - intersectionRectangle.Width;
                        }
                        else
                        {
                            xpos = xpos + intersectionRectangle.Width;

                        }
                        if (myLuigi.IsDead())
                        {
                            hud.lifeLostLuigi();
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
