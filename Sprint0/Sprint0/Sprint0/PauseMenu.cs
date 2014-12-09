using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class PauseMenu
    {
        SpriteFont font;
        Vector2 position;
        Color color = new Color(255, 255, 255, 255);

        public PauseMenu (SpriteFont newfont)
        {
            font = newfont;
        }

        public void Update()
        {
            //nothing needed
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(font, "Press 'u' to resume play\nPress 'q' to quit\nPress '0' to return to Main Menu\n\n\nGame Controls:\na: left\nd: right\ns: crouch\nz: run\nx: jump\n\nDuring play press 'p' to pause or 'r' to reset" , position, color);
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
    }
}
