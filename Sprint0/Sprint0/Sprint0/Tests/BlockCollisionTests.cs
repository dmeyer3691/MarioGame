using System;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using TeamYoshi;
using TeamYoshi.Blocks;
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
    class BlockCollisionTests
    {

        // Mario
        static Camera nullCamera = new Camera();
        static SoundEffects sound = new SoundEffects();
        static IList<IProjectile> projectiles = new List<IProjectile>();
        Mario mario = new Mario(400, 405,nullCamera, sound, projectiles);
        // Blocks
        // Brick, TopBrick, QBlock to hit
        IBlock hitBrick = new Brick(400, 400, nullCamera);
        IBlock hitItemBrick = new Brick(400, 400, nullCamera, BrickState.bstar);
        IBlock hitQBlock = new Brick(400, 400, nullCamera, BrickState.qempty);
        // Safe blocks
        IBlock safeBrick = new Brick(0, 0, nullCamera);
        IBlock safeHitQBlock = new Brick(10, 10, nullCamera, BrickState.qempty);
        IBlock safePipe = new Pipe(20, 20, nullCamera);
        IBlock safeQBlock = new Brick(30, 30, nullCamera, BrickState.qcoin);
        IBlock safeRP = new RoughPlatform(40, 40, nullCamera);
        IBlock safeSP = new SmoothPlatform(50, 50, nullCamera);
        IBlock safeItemBrick = new Brick(60, 60, nullCamera, BrickState.bstar);

        public void RunBlockTests()
        {
            BrickBroken();
            TopBrickBroken();
            QBlockHit();
            BrickNoCollision();
            HitQBlockNoCollision();
            PipeNoCollision();
            QBlockNoCollision();
            RoughPlatformNoCollision();
            SmoothPlatformNoCollision();
            TopBrickNoCollision();

            Console.WriteLine("Block Collision Tests Successful");
        }

        private int CollisionDetectionHelper(Rectangle marioRectangle, Rectangle blockRectangle)
        {
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, blockRectangle);

            if (intersectionRectangle.IsEmpty)
            {
                // No Collision
                return 0;
            }
            if ((intersectionRectangle.Width >= intersectionRectangle.Height))
            {
                // Block breaks
                return 1;
            }
            else return 2;
}

        public void BrickBroken() 
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), hitBrick.GetRectangle());
            Debug.Assert(i == 1);
        }
        public void TopBrickBroken()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), hitItemBrick.GetRectangle());
            Debug.Assert(i == 1);
        }
        public void QBlockHit()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), hitQBlock.GetRectangle());
            Debug.Assert(i == 1);
        }
        public void BrickNoCollision()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), safeBrick.GetRectangle());
            Debug.Assert(i == 0);
        }
        public void HitQBlockNoCollision()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), safeHitQBlock.GetRectangle());
            Debug.Assert(i == 0);
        }
        public void PipeNoCollision()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), safePipe.GetRectangle());
            Debug.Assert(i == 0);
        }
        public void QBlockNoCollision()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), safeQBlock.GetRectangle());
            Debug.Assert(i == 0);
        }
        public void RoughPlatformNoCollision()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), safeRP.GetRectangle());
            Debug.Assert(i == 0);
        }
        public void SmoothPlatformNoCollision()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), safeSP.GetRectangle());
            Debug.Assert(i == 0);
        }
        public void TopBrickNoCollision()
        {
            int i = CollisionDetectionHelper(mario.GetRectangle(), safeItemBrick.GetRectangle());
            Debug.Assert(i == 0);
        }
    }
}