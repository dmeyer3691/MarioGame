using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi.Commands
{
    class CrouchCommand : ICommand
    {

        IPlayer player;

        public CrouchCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Crouch();
        }
    }
}
