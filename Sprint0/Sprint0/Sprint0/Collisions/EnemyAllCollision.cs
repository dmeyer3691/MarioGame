using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Collisions
{
    public class EnemyAllCollision
    {
        
        private IEnemy myEnemy;

        public EnemyAllCollision(IEnemy enemy)
        {
            myEnemy = enemy;
        }

        public void BlockCollisionTest(IList<IBlock> blocks)
        {
            Rectangle myRectangle = myEnemy.GetRectangle();
            Rectangle blockRectangle;
            Rectangle intersectionRectangle;

            foreach (IBlock block in blocks)
            {

                blockRectangle = block.GetRectangle();

                intersectionRectangle = Rectangle.Intersect(myRectangle, blockRectangle);

                if (!intersectionRectangle.IsEmpty)
                {
                    if (intersectionRectangle.Width >= intersectionRectangle.Height)
                    {
                        if (myRectangle.Y <= blockRectangle.Y)
                        {
                            myEnemy.Fall(intersectionRectangle.Height);
                        }
                    }

                    else if (myRectangle.X <= blockRectangle.X)
                    {
                        if (myRectangle.Y >= blockRectangle.Y)
                        {
                            myEnemy.Reverse(intersectionRectangle.Width);
                        }
                    }
                    else if (myRectangle.X >= blockRectangle.X)
                    {
                        if (myRectangle.Y >= blockRectangle.Y)
                        {
                            myEnemy.Reverse(intersectionRectangle.Width);
                        }
                    }
                }
                

            }
        }

        public void EnemyCollisionTest(IList<IEnemy> enemies)
        {
            Rectangle myRectangle = myEnemy.GetRectangle();
            Rectangle enemyRectangle;
            Rectangle intersectionRectangle;

            foreach (IEnemy enemy in enemies)
            {

                enemyRectangle = enemy.GetRectangle();
                intersectionRectangle = Rectangle.Intersect(myRectangle, enemyRectangle);

                if (!intersectionRectangle.IsEmpty)
                {
                    if (myRectangle.X < enemyRectangle.X)
                    {
                        myEnemy.Reverse(intersectionRectangle.Width / 2);
                        enemy.Reverse(intersectionRectangle.Width / 2);
                    }
                    else if (myRectangle.X > enemyRectangle.X)
                    {
                        myEnemy.Reverse(intersectionRectangle.Width / 2);
                        enemy.Reverse(intersectionRectangle.Width / 2);
                    }
                }

            }
            
        }
    }
}
