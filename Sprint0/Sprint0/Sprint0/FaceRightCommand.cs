using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint0
{
    class FaceRightCommand
    {
        void execute(IAnimatedSprite sprite)
        {
            sprite.FaceRight();
        }
    }
}
