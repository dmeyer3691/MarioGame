using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public class MarioLevel
    {
        private IList<IItem> itemList;
        private IList<IEnemy> enemyList;
        private IList<IBlock> blockList;
        public Mario mario;
        private Camera camera;
        private Background background;
        public MarioLevel(IList<IItem> i, IList<IEnemy> e, IList<IBlock> b, Mario m, Camera c)
        {            
            itemList = i;
            enemyList = e;
            blockList = b;
            mario = m;
            camera = c;
            background = new Background(c);
        }

        public void Draw()
        {
            //draw background 
            background.Draw();
            // draw game objects
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw();
            }
            foreach (IItem item in itemList)
            {
                item.Draw();
            }
            foreach (IBlock block in blockList)
            {
                block.Draw();
            }
            mario.Draw();
        }

        public void Update()
        {
            camera.Update();
            background.Update();

            mario.Update();

            // update game objects
            if (!mario.State.IsDead() && !mario.State.IsHit())
            {

                foreach (IItem item in itemList)
                {
                    item.Update(blockList);
                }
                foreach (IEnemy enemy in enemyList)
                {
                    enemy.Update(blockList, enemyList);
                }
                foreach (IBlock block in blockList)
                {
                    block.Update();
                }
               
            }
            if (!mario.State.IsDead())
            {
                mario.BlockCollisionTest(blockList, itemList);
                mario.ItemCollisionTest(itemList);
                mario.EnemyCollisionTest(enemyList);
            }
        }
    }
}
