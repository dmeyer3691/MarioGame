using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0
{
    public interface IProjectile
    {
        void Draw();
        void Update();
        void ShootProjectile();
    }
}
