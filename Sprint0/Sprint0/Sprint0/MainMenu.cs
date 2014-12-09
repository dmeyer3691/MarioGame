using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class MainMenu
    {
        SpriteFont font;
        Vector2 position;
        Color color = new Color(255, 255, 255, 255);

        public MainMenu (SpriteFont newfont)
        {
            font = newfont;
        }

        public void Update()
        {
            //nothing needed
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.DrawString(font, "Press '1' for single player\nPress '2' for two player mode\nPress 'q' to quit" , position, color);
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
    }
}
