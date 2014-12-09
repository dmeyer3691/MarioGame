using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class StandCommand : ICommand
    {
        IPlayer player;

        public StandCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Stand();
        }
    }
}
