using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public interface IBlock
    {
        void Draw();
        void Update();
        Rectangle GetRectangle();
        void Hit(IList<IItem> items, bool isMario, bool isBig, HUD hud, SoundEffects sound);
    }
}
