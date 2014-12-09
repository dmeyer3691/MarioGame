using System;
using Microsoft.Xna.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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



namespace TeamYoshiTests
{
    [TestClass]
    public class ItemCollisionTests
    {



        //Mario
        Mario mario = new Mario(400, 400);
        //Objects to collide
        Coin coin = new Coin(400, 400);
        Fireflower fireflower = new Fireflower(400, 400);
        Mushroom mushroom = new Mushroom(400, 400);
        Oneup oneup = new Oneup(400, 400);
        Star star = new Star(400, 400);
        //Objects not colliding
        Coin coinSafe = new Coin(0, 0);
        Fireflower fireflowerSafe = new Fireflower(0, 0);
        Mushroom mushroomSafe = new Mushroom(0, 0);
        Oneup oneupSafe = new Oneup(0, 0);
        Star starSafe = new Star(0, 0);

        private bool CollisionDetectionHelper(Rectangle marioRectangle, Rectangle itemRectangle)
        {
            Rectangle intersectionRectangle = Rectangle.Intersect(marioRectangle, itemRectangle);
            return !intersectionRectangle.IsEmpty;
        }

        [TestMethod]
        public void TestCoinSafe()
        {
            Assert.IsFalse(CollisionDetectionHelper(mario.GetRectangle(), coinSafe.GetRectangle()));
        }

        [TestMethod]
        public void TestFireflowerSafe()
        {
            Assert.IsFalse(CollisionDetectionHelper(mario.GetRectangle(), fireflowerSafe.GetRectangle()));
        }
        [TestMethod]
        public void TestMushroomSafe()
        {
            Assert.IsFalse(CollisionDetectionHelper(mario.GetRectangle(), mushroomSafe.GetRectangle()));
        }
        [TestMethod]
        public void TestOneupSafe()
        {
            Assert.IsFalse(CollisionDetectionHelper(mario.GetRectangle(), oneupSafe.GetRectangle()));
        }
        [TestMethod]
        public void TestStarSafe()
        {
            Assert.IsFalse(CollisionDetectionHelper(mario.GetRectangle(), starSafe.GetRectangle()));
        }
        [TestMethod]
        public void TestCoinCollision()
        {
            Assert.IsTrue(CollisionDetectionHelper(mario.GetRectangle(), coin.GetRectangle()));
        }
        [TestMethod]
        public void TestFireflowerCollision()
        {
            Assert.IsTrue(CollisionDetectionHelper(mario.GetRectangle(), fireflower.GetRectangle()));
        }
        [TestMethod]
        public void TestMushroomCollision()
        {
            Assert.IsTrue(CollisionDetectionHelper(mario.GetRectangle(), mushroom.GetRectangle()));
        }
        [TestMethod]
        public void TestOneupCollision()
        {
            Assert.IsTrue(CollisionDetectionHelper(mario.GetRectangle(), oneup.GetRectangle()));
        }
        [TestMethod]
        public void TestStarCollision()
        {
            Assert.IsTrue(CollisionDetectionHelper(mario.GetRectangle(), star.GetRectangle()));
        }

    }
}
