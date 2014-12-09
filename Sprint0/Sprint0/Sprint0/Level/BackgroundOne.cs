using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi
{
    class BackgroundOne
    {
        private ISprite BackgroundSprite = new Sprites.BackgroundSprite();
        Camera camera;
        
        public BackgroundOne(Camera cam)
        {
            camera = cam;
        }


        public void Draw()
        {
            if (camera.CameraPos() >= 0)
            {
                camera.Draw(BackgroundSprite, camera.CameraPos(), Constants.levelHeight);
            }
        }

        public void Update()
        {
        }

    }
}
