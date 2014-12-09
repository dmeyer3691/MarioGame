using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using TeamYoshi;
using TeamYoshi.Enemies;
using TeamYoshi.Sprites;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace TeamYoshi
{

    public class EnemyCollisionTests
    {

        static Camera nullCamera = new Camera();
        static SoundEffects sound = new SoundEffects();
        static IList<IProjectile> projectiles = new List<IProjectile>();
        //Mario
        Mario mario = new Mario(400, 400,nullCamera, sound, projectiles);
        //Enemies killed
        Goomba goomba1 = new Goomba(400, 405, nullCamera);
        GreenKoopa gKoopa1 = new GreenKoopa(400, 405, nullCamera);
        //Enemies Killing
        Piranha piranha2 = new Piranha(405, 400, nullCamera);
        RedKoopa rKoopa2 = new RedKoopa(405, 400, nullCamera);
        //Objects not colliding
        Goomba goomba3 = new Goomba(0, 0, nullCamera);
        GreenKoopa gKoopa3 = new GreenKoopa(100, 100, nullCamera);


        public void RunEnemyTests()
        {
            GoombaKilled();
            GreenKoopaKilled();
            RedKoopaKilledMario();
            PiranhaKilledMario();
            GoombaSafe();
            GreenKoopaSafe();

            Console.WriteLine("Enemy Collision Tests Successful");
        }

        private int CollisionDetectionHelper(Rectangle marioRectangle, Rectangle itemRectangle)
        {
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, itemRectangle);

            if (intersectionRectangle.IsEmpty)
            {
                // No Collision
                return 0;
            }
            if (intersectionRectangle.Width >= intersectionRectangle.Height)
            {
                // Mario kills
                return 1;
            }
            else if (intersectionRectangle.Height > intersectionRectangle.Width)
            {
                // Mario Dead
                return 2;
            }
            else
            {
                Debug.Assert(false);
                return -1;
            }

        }


        public void GoombaKilled()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), goomba1.GetRectangle());
            Debug.Assert(i == 1);
        }

        public void GreenKoopaKilled()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), gKoopa1.GetRectangle());
            Debug.Assert(i == 1);
        }

        public void PiranhaKilledMario()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), rKoopa2.GetRectangle());
            Debug.Assert(i == 2);
        }

        public void RedKoopaKilledMario()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), piranha2.GetRectangle());
            Debug.Assert(i == 2);
        }

        public void GoombaSafe()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), goomba3.GetRectangle());
            Debug.Assert(i == 0);
        }

        public void GreenKoopaSafe()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), gKoopa3.GetRectangle());
            Debug.Assert(i == 0);
        }

    }
}
