using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    public interface IPlayer
    {
        void Draw();
        void Update();
        Rectangle GetRectangle();
        void Crouch();
        void Dead();
        void Right();
        void Left();
        void Run();
        void Stand();
        void Walk();
        void Jump();
        void Fireball();
    }
}
