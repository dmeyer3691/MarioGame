using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Commands
{
    class RightCommand : ICommand
    {

        IPlayer player;

        public RightCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Right();
        }
    }
}
