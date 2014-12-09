using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TeamYoshi
{
    public interface IProjectile
    {
        void Draw();
        void Update(IList<IBlock> blocks, IList<IEnemy> enemies);
        Rectangle GetRectangle();
        bool DestroyProjectile();
    }
}
