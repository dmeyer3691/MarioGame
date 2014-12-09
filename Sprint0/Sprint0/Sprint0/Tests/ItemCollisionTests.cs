using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using TeamYoshi;
using TeamYoshi.Items;
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
    public class ItemCollisionTests
    {
        static Camera nullCamera = new Camera();
        static SoundEffects sound = new SoundEffects();
        static IList<IProjectile> projectiles = new List<IProjectile>();
        //Mario
        Mario mario = new Mario(400, 400,nullCamera, sound, projectiles);
        //Objects to collide
        Coin coin = new Coin(400, 400, nullCamera);
        Fireflower fireflower = new Fireflower(400, 400, nullCamera);
        Mushroom mushroom = new Mushroom(400, 400, nullCamera);
        Oneup oneup = new Oneup(400, 400, nullCamera);
        Star star = new Star(400, 400, nullCamera);
        //Objects not colliding
        Coin coinSafe = new Coin(0, 0, nullCamera);
        Fireflower fireflowerSafe = new Fireflower(0, 0, nullCamera);
        Mushroom mushroomSafe = new Mushroom(0, 0, nullCamera);
        Oneup oneupSafe = new Oneup(0, 0, nullCamera);
        Star starSafe = new Star(0, 0, nullCamera);

        public void RunItemTests()
        {
            TestCoinSafe();
            TestCoinCollision();
            TestMushroomSafe();
            TestMushroomCollision();
            TestFireflowerSafe();
            TestFireflowerCollision();
            TestOneupSafe();
            TestOneupCollision();
            TestStarSafe();
            TestStarCollision();

            Console.WriteLine("Item Collision Tests Successful");
        }

        private bool CollisionDetectionHelper(Rectangle marioRectangle, Rectangle itemRectangle)
        {
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, itemRectangle);
            return !intersectionRectangle.IsEmpty;
        }

        public void TestCoinSafe()
        {
            Debug.Assert(!CollisionDetectionHelper(mario.GetRectangle(), coinSafe.GetRectangle()));
        }

        public void TestFireflowerSafe()
        {
            Debug.Assert(!CollisionDetectionHelper(mario.GetRectangle(), fireflowerSafe.GetRectangle()));
        }
        public void TestMushroomSafe()
        {
            Debug.Assert(!CollisionDetectionHelper(mario.GetRectangle(), mushroomSafe.GetRectangle()));
        }
        public void TestOneupSafe()
        {
            Debug.Assert(!CollisionDetectionHelper(mario.GetRectangle(), oneupSafe.GetRectangle()));
        }
        public void TestStarSafe()
        {
            Debug.Assert(!CollisionDetectionHelper(mario.GetRectangle(), starSafe.GetRectangle()));
        }
        public void TestCoinCollision()
        {
            Debug.Assert(CollisionDetectionHelper(mario.GetRectangle(), coin.GetRectangle()));
        }
        public void TestFireflowerCollision()
        {
            Debug.Assert(CollisionDetectionHelper(mario.GetRectangle(), fireflower.GetRectangle()));
        }
        public void TestMushroomCollision()
        {
            Debug.Assert(CollisionDetectionHelper(mario.GetRectangle(), mushroom.GetRectangle()));
        }
        public void TestOneupCollision()
        {
            Debug.Assert(CollisionDetectionHelper(mario.GetRectangle(), oneup.GetRectangle()));
        }
        public void TestStarCollision()
        {
            Debug.Assert(CollisionDetectionHelper(mario.GetRectangle(), star.GetRectangle()));
        }

    }
}
