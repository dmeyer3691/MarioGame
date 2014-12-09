using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public interface IItem
    {
        void Draw();
        void Reverse();
        void Update(IList<IBlock> blocks);
        Rectangle GetRectangle();
        String GetItemName();
        void moveYPosition(int offset);
        bool DestroyItem();
    }
}
