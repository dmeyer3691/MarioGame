using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Enemies
{
    public class Goomba : IEnemy
    {

        private Collisions.EnemyAllCollision enemyAllCollisions;
        bool movingRight;
        bool found;

        private static ISprite GoombaSprite = new Sprites.GoombaSprite();
        private int xPosition;
        private int yPosition;
        Camera camera;

        public Goomba(int x, int y, Camera cam)
        {
            enemyAllCollisions = new Collisions.EnemyAllCollision(this);
            found = false;
            camera = cam;
            xPosition = x;
            yPosition = y;
        }

        public void Draw()
        {
            camera.Draw(GoombaSprite, xPosition, yPosition);
        }
        public void Fall(int f)
        {
            yPosition = yPosition - f;
        }

        public void Reverse(int w)
        {
            if (movingRight)
            {
                xPosition = xPosition - w;
                movingRight = false;
            }
            else
            {
                xPosition = xPosition + w;
                movingRight = true;
            }
        }

        public void Update(IList<IBlock> blocks, IList<IEnemy> enemies)
        {
            int cam = camera.CameraPos();
            if ((cam + Constants.enemyWakeDistance) > xPosition)
            {
                found = true;
            }
            if (found)
            {
                yPosition++;
                enemyAllCollisions.BlockCollisionTest(blocks);
                enemyAllCollisions.EnemyCollisionTest(enemies);

                if (movingRight)
                {
                    xPosition++;
                }
                else
                {
                    xPosition--;
                }

                GoombaSprite.Update();
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, GoombaSprite.GetWidth(), GoombaSprite.GetHeight());
        }
    }
}
