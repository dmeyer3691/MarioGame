using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0
{
    interface IState
    {
        void Update();
        void Draw(int x, int y);
        
    }
}
