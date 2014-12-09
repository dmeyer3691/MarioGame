using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TeamYoshi.Collisions
{
    public class MarioLuigiCollision
    {
        private Mario myMario;

        public MarioLuigiCollision(Mario mario)
        {
            myMario = mario;
        }

        public void MarioLuigiCollisionTest(Mario mario, Luigi luigi, SoundEffects sound)
        {
            Rectangle marioRectangle = myMario.GetRectangle();
            Rectangle luigiRectangle = luigi.GetRectangle();
            Rectangle intersectionRectangle;

            intersectionRectangle = Rectangle.Intersect(marioRectangle, luigiRectangle);

            if (!intersectionRectangle.IsEmpty)
            {
                if (intersectionRectangle.Width > intersectionRectangle.Height)
                {
                    if (marioRectangle.Y > luigiRectangle.Y)
                    {
                        luigi.BoostJump();
                        sound.Bump();

                    } 
                    else if (luigiRectangle.Y > marioRectangle.Y)
                    {
                        mario.BoostJump();
                        sound.Bump();
                    }
                }
            }
        }
    }
}
