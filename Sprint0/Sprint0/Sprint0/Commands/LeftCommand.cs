using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Commands
{
    class LeftCommand : ICommand
    {

        IPlayer player;

        public LeftCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Left();
        }
    }
}
