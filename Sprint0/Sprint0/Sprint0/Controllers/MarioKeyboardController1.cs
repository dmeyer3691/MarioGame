using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamYoshi.Commands;

namespace TeamYoshi
{
    class MarioKeyboardController1 : IController
    {

        private KeyboardState prev;
        private enum PossibleCommands { left, right, crouch, stand, run, jump, fireball, reset, quit, pause, unpause, oneplayer, twoplayer, mainmenu };
        private Dictionary<Keys, PossibleCommands> keymap;
        private bool paused = false;

        public bool isPaused()
        {
            return paused;
        }

        public MarioKeyboardController1()
        {
            prev = Keyboard.GetState();
            keymap = new Dictionary<Keys, PossibleCommands>();
            keymap.Add(Keys.A, PossibleCommands.left);
            keymap.Add(Keys.Left, PossibleCommands.left);
            keymap.Add(Keys.D, PossibleCommands.right);
            keymap.Add(Keys.Right, PossibleCommands.right);
            keymap.Add(Keys.S, PossibleCommands.crouch);
            keymap.Add(Keys.Down, PossibleCommands.crouch);
            keymap.Add(Keys.Z, PossibleCommands.run);
            keymap.Add(Keys.L, PossibleCommands.run);
            keymap.Add(Keys.X, PossibleCommands.jump);
            keymap.Add(Keys.K, PossibleCommands.jump);
            keymap.Add(Keys.R, PossibleCommands.reset);
            keymap.Add(Keys.Q, PossibleCommands.quit);
            keymap.Add(Keys.P, PossibleCommands.pause);
            keymap.Add(Keys.U, PossibleCommands.unpause);
            keymap.Add(Keys.E, PossibleCommands.fireball);
            keymap.Add(Keys.D1, PossibleCommands.oneplayer);
            keymap.Add(Keys.D2, PossibleCommands.twoplayer);
            keymap.Add(Keys.D0, PossibleCommands.mainmenu);
        }

        private bool keyPressed(Keys k, KeyboardState current)
        {
            return (current.IsKeyDown(k) && !prev.IsKeyDown(k));
        }

        private bool marioCanMove(IPlayer mario)
        {
            return !((Mario)mario).IsDead();
        }

        public void Update(Sprint4 game, IPlayer mario)
        {
            bool aKeyIsPressed = false;
            Sprint4.GameState gameState = game.getGameState();
            KeyboardState curr = Keyboard.GetState();


            foreach (KeyValuePair<Keys, PossibleCommands> key in keymap)
            {
                if (keyPressed(key.Key, curr))
                {
                    aKeyIsPressed = true;
                    //let these in even if mario is dead/hit
                    switch (gameState)
                    {
                        case Sprint4.GameState.MainMenu:
                            switch (key.Value)
                            {
                                case PossibleCommands.quit:
                                    game.Exit();
                                    break;
                                case PossibleCommands.oneplayer:
                                    game.setGameState(Sprint4.GameState.OnePlayer);
                                    break;
                                case PossibleCommands.twoplayer:
                                    game.setGameState(Sprint4.GameState.TwoPlayer);
                                    break;
                            }
                            break;
                        case Sprint4.GameState.Pause:
                            switch (key.Value)
                            {
                                case PossibleCommands.unpause:
                                    game.UnPause();
                                    break;
                                case PossibleCommands.mainmenu:
                                    game.Reset();
                                    game.setGameState(Sprint4.GameState.MainMenu);
                                    break;
                                case PossibleCommands.quit:
                                    game.Exit();
                                    break;
                            }
                            break;
                        case Sprint4.GameState.OnePlayer:
                            switch (key.Value)
                            {
                                case PossibleCommands.pause:
                                    game.Pause();
                                    break;
                                case PossibleCommands.reset:
                                    game.Reset();
                                    break;
                                default:
                                    if (marioCanMove(mario))
                                    {
                                        switch (key.Value)
                                        {
                                            case PossibleCommands.left:
                                                new LeftCommand(mario).Execute();
                                                break;
                                            case PossibleCommands.right:
                                                new RightCommand(mario).Execute();
                                                break;
                                            case PossibleCommands.run:
                                                new RunCommand(mario).Execute();
                                                break;
                                            case PossibleCommands.jump:
                                                new JumpCommand(mario).Execute();
                                                break;
                                            case PossibleCommands.crouch:
                                                new CrouchCommand(mario).Execute();
                                                break;
                                            case PossibleCommands.fireball:
                                                new FireballCommand(mario).Execute();
                                                break;
                                        }
                                    }
                                    break;
                            }
                            break;
                        case Sprint4.GameState.TwoPlayer:
                            //nothing to do
                            break;
                    }
                }
            }
            if (!aKeyIsPressed && marioCanMove(mario)) new StandCommand(mario).Execute();
            //prev = curr; //if we want to do this we'll need to update command logic accordingly. I'm all for it and think it will make things less glitchy, but I'll leave it alone for now.

        }
    }
}
