using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class WalkCommand : ICommand
    {

        IPlayer player;

        public WalkCommand(Mario myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Walk();
        }
    }
}
