using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class DeadCommand : ICommand
    {
        IPlayer player;

        public DeadCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Dead();
        }
    }
}
