using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public class OnePlayerLevel
    {
        private IList<IItem> itemList;
        private IList<IEnemy> enemyList;
        private IList<IBlock> blockList;
        private IList<IProjectile> projectileList;
        public Mario mario;
        private Camera camera;
        private BackgroundOne background;
        private UndergroundBackground undergroundBackground;
        public HUD hud;
        public SoundEffects sound;
        private Blocks.Flagpole flagpole;
        private bool onFlagpole;
        private FlagMario flagMario;
        public OnePlayerLevel(IList<IItem> i, IList<IEnemy> e, IList<IBlock> b, IList<IProjectile> p, Mario m, Camera c, HUD h, SoundEffects s, Blocks.Flagpole f)
        {
            itemList = i;
            enemyList = e;
            blockList = b;
            projectileList = p;
            mario = m;
            camera = c;
            background = new BackgroundOne(c);
            undergroundBackground = new UndergroundBackground(c);
            hud = h;
            sound = s;
            flagpole = f;
            onFlagpole = false;
        }

        public void Draw(GraphicsDevice d)
        {
            d.Clear(Constants.backgroundOneColor);
            //draw background 
            if (mario.getXPosition() >= 0)
            {
                background.Draw();
            }
            else
            {
                undergroundBackground.Draw();
            }
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
            foreach (IProjectile proj in projectileList)
            {
                proj.Draw();
            }
            flagpole.Draw();
            if (onFlagpole) flagMario.Draw();
            else mario.Draw();
        }

        public void CreateFireball(Fireball fb)
        {
            projectileList.Add(fb);
        }

        public void DestroyFireball(Fireball fb)
        {
            projectileList.Remove(fb);
        }

        public void Update()
        {
            camera.Update();
            background.Update();

            // update game objects
            if (!mario.IsDead() && !mario.IsHit() && !mario.GettingItem())
            {
                Queue<IItem> doomedItems = new Queue<IItem>();
                Queue<IProjectile> doomedP = new Queue<IProjectile>();
                foreach (IItem item in itemList)
                {
                    item.Update(blockList);
                    if (item.DestroyItem())
                    {
                        doomedItems.Enqueue(item);
                    }
                }
                while (doomedItems.Count() > 0)
                {
                    IItem items = doomedItems.Dequeue();
                    itemList.Remove(items);
                }

                foreach (IEnemy enemy in enemyList)
                {
                    enemy.Update(blockList, enemyList);
                }
                foreach (IBlock block in blockList)
                {
                    block.Update();
                }
                foreach (IProjectile projectile in projectileList)
                {
                    projectile.Update(blockList, enemyList);
                    if (projectile.DestroyProjectile())
                    {
                        doomedP.Enqueue(projectile);
                    }
                }
                while (doomedP.Count() > 0)
                {
                    IProjectile projectile = doomedP.Dequeue();
                    projectileList.Remove(projectile);
                }
               
            }
            if (!mario.IsDead())
            {
                mario.BlockCollisionTest(hud, blockList, itemList);
                mario.ItemCollisionTest(hud, itemList);
                mario.EnemyCollisionTest(hud, enemyList);
            }
            if ((mario.getXPosition() >= Constants.flagpoleEdge) && onFlagpole == false)
            {
                hud.achievements.Ending();
                sound.FlagPole();
                onFlagpole = true;
                FlagMario.marioPowerupState m;
                if (!mario.IsLarge()) m = FlagMario.marioPowerupState.small;
                else if (mario.HasFire()) m = FlagMario.marioPowerupState.fire;
                else m = FlagMario.marioPowerupState.big;
                flagMario = new FlagMario(mario.getXPosition(),mario.getYPosition(),camera,m);
            }
            if (onFlagpole) flagMario.Update();
            else mario.Update();
        }

    }

}
