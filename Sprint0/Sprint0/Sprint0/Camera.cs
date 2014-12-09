using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public class Camera
    {
        private int xPos; //camera doesn't need to alter y positions because our camera only pans left-right (actually, only right)
        private Mario mario;//camera needs mario so that camera can update its xPos based on mario's location.
        public Camera()
        {
            mario = null;
            xPos = 0;//this should probably actually be tied to the x position mario starts in. 0 works for now, but when we add the return from the secret area, it wont.
        }

        //because mario needs camera and camera needs mario, this Init is used to deal with the circular dependency between them.
        public void Init(Mario m)
        {
            mario = m;
        }

        public void Update()
        {
            int marioXPos = mario.GetRectangle().X;
            if ((marioXPos - xPos) > Constants.cameraBuffer)
            {
                xPos += Constants.cameraVelocity;
            }
        }

        public int CameraPos()
        {
            return xPos;
        }

        public void Draw(ISprite sprite, int x, int y, Microsoft.Xna.Framework.Graphics.SpriteEffects facing)
        {
            if(sprite != null) sprite.Draw(x-xPos, y, facing);
        }
        
        //as the code suggests, this draw calls into its parent draw. it exists simply to make calls to draw that don't require a facing direction (I.E. things that never change facing)
        public void Draw(ISprite sprite, int x, int y)
        {
            this.Draw(sprite,x,y,Microsoft.Xna.Framework.Graphics.SpriteEffects.None);
        }

        //necessary for warping
        public void SetXPos(int x)
        {
            xPos = x;
        }
    }
}
