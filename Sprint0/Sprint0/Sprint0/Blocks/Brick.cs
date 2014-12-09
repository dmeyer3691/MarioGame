using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi.Blocks
{
    public enum BrickState
    {
            bempty, bcoin, bstar, qcoin, qempty, qitem, qlife, destroyed
    } //public for constructor purposes

    class Brick : IBlock
    {

        private ISprite BrickSprite;//this cannot be static because there are multiple bricks with discrete sprites.
        private BrickState state;
        private int xPosition;
        private int yPosition;
        private Camera camera;

        public Brick(int x, int y, Camera cam, BrickState s)
        {
            xPosition = x;
            yPosition = y;
            camera = cam;
            state = s;
            switch (s)
            {
                case BrickState.qempty:
                    //this never happens in our level, but it's good to have in theory.
                    BrickSprite = new Sprites.HitQBlockSprite();
                    break;
                case BrickState.bempty:
                case BrickState.bcoin:
                case BrickState.bstar:
                    BrickSprite = new Sprites.TopBrickSprite();
                    break;
                case BrickState.destroyed:
                    BrickSprite = null;
                    break;
                default:
                    BrickSprite = new Sprites.QBlockSprite();
                    break;
            }
        }

        public Brick(int x, int y, Camera cam) : this(x, y, cam, BrickState.bempty) { }

        public void Draw()
        {
            if (BrickSprite != null && state != BrickState.qlife)
            {
                camera.Draw(BrickSprite, xPosition, yPosition);
            }
        }

        public void Update()
        {
        }

        public Rectangle GetRectangle()
        {
            if (BrickSprite == null) return new Rectangle(0, 0, 0, 0);
            return new Rectangle(xPosition, yPosition, BrickSprite.GetWidth(), BrickSprite.GetHeight());
        }



        //this is coupled with a few things it doesn't need to be.
        public void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound)
        {
            switch (state)
            {
                case BrickState.bstar:
                    sound.Popup();
                    IItem star = new Items.Star(xPosition, yPosition - 16, camera);
                    items.Add(star);
                    state = BrickState.qempty;
                    BrickSprite = new Sprites.HitQBlockSprite();
                    break;

                case BrickState.bcoin:
                    sound.Coin();
                    IItem c;
                    //make the coin noise
                    c = new Items.Coin(xPosition, yPosition - Constants.tileLength, camera);
                    items.Add(c);
                    if (isMario)
                    {
                        hud.increaseScoreMario(Constants.brokenBrickValue);
                        hud.addCoinMario();
                    }
                    else
                    {
                        hud.increaseScoreLuigi(Constants.brokenBrickValue);
                        hud.addCoinLuigi();
                    }
                    state = BrickState.qempty;
                    BrickSprite = new Sprites.HitQBlockSprite();
                    break;

                case BrickState.bempty:
                    if (isBig)
                    {
                        sound.BreakBlock();
                        if (isMario)
                        {
                            hud.increaseScoreMario(Constants.brokenBrickValue);
                        }
                        else
                        {
                            hud.increaseScoreLuigi(Constants.brokenBrickValue);
                        }
                        state = BrickState.destroyed;
                        BrickSprite = null;
                    }
                    break;

                case BrickState.qitem:
                    IItem i;
                    sound.Popup();
                    if (!isBig) {
                        i = new Items.Mushroom(xPosition, yPosition - Constants.tileLength, camera); 
                    }
                    
                    else {
                        i = new Items.Fireflower(xPosition, yPosition - Constants.tileLength, camera);
                    }
                    items.Add(i);
                    state = BrickState.qempty;
                    BrickSprite = new Sprites.HitQBlockSprite();
                    break;

                case BrickState.qlife:
                    items.Add(new Items.Oneup(xPosition, yPosition - Constants.tileLength, camera));
                    state = BrickState.qempty;
                    BrickSprite = new Sprites.HitQBlockSprite();
                    break;


                case BrickState.qcoin:
                    sound.Coin();
                    //make the coin noise
                    c = new Items.Coin(xPosition, yPosition - Constants.tileLength, camera);
                    items.Add(c);
                    if (isMario)
                    {
                        hud.increaseScoreMario(Constants.brokenBrickValue);
                        hud.addCoinMario();
                    }
                    else
                    {
                        hud.increaseScoreLuigi(Constants.brokenBrickValue);
                        hud.addCoinLuigi();
                    }
                    state = BrickState.qempty;
                    BrickSprite = new Sprites.HitQBlockSprite();
                    break;
                default:
                    break;
            }
        }
    }
}
