using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0
{
    class FaceLeftCommand
    {
        void Execute(IAnimatedSprite sprite)
        {
            sprite.FaceLeft();
        }
    }
}
