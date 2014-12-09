using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class RunCommand : ICommand
    {

        IPlayer player;

        public RunCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Run();
        }
    }
}
