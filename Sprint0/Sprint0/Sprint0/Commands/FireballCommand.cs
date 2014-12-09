using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamYoshi
{
    class FireballCommand : ICommand
    {
        IPlayer player;

        public FireballCommand(IPlayer myPlayer)
        {
            player = myPlayer;
        }

        public void Execute()
        {
            player.Fireball();
        }
    }
}
