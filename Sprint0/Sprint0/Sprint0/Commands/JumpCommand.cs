using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class JumpCommand : ICommand
    {

        IPlayer player;

        public JumpCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Jump();
        }
    }
}
