using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamYoshi.Commands;

namespace TeamYoshi
{
    class GamepadController : IController
    {

        ICommand command;

        public void Update(Sprint4 game, IPlayer mario)
        {

            //todo: convert to switch case
            //need to test this somehow

            // quit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                game.Exit();
            }
            // up
            else if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                command = new JumpCommand(mario);
                command.Execute();
            }
            // left
            else if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                command = new LeftCommand(mario);
                command.Execute();
            }
            // right
            else if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                command = new RightCommand(mario);
                command.Execute();
            }
            // down
            else if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                command = new CrouchCommand(mario);
                command.Execute();
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                game.Reset();
            }
            else
            {
                command = new StandCommand(mario);
                command.Execute();
            }

        }

    }
}
