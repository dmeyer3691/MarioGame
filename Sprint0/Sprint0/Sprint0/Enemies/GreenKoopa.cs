using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Enemies
{
    public class GreenKoopa : IEnemy
    {
        private Collisions.EnemyAllCollision enemyAllCollisions;
        bool movingRight;
        bool found;
        private SpriteEffects facing;

        private static ISprite KoopaSprite = new Sprites.GreenTurtleSprite();
        private int xPosition;
        private int yPosition;
        private Camera camera;
        public GreenKoopa(int x, int y, Camera cam)
        {
            enemyAllCollisions = new Collisions.EnemyAllCollision(this);
            facing = SpriteEffects.None;
            found = false;
            camera = cam;
            xPosition = x;
            yPosition = y;
        }
        
        public void Draw()
        {
            camera.Draw(KoopaSprite, xPosition, yPosition, facing);
        }
        public void Fall(int f)
        {
            yPosition = yPosition - f;
        }

        public void Reverse(int w)
        {
            
            if (movingRight)
            {
                facing = SpriteEffects.None;
                xPosition = xPosition - w;
                movingRight = false;
            }
            else
            { 
                facing = SpriteEffects.FlipHorizontally;
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

                KoopaSprite.Update();
            }
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(xPosition, yPosition, KoopaSprite.GetWidth(), KoopaSprite.GetHeight());
        }
    }
}
