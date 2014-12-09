using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;


namespace TeamYoshi
{
    /// <summary>
    /// This is the main type for your game..
    /// </summary>
    public class Sprint4 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        private ArrayList GameControllers;
        private OnePlayerLevel onePlayerLevel;
        private TwoPlayerLevel twoPlayerLevel;
        private SpriteFont Font;
        private SoundEffects soundEffect;
        private MarioKeyboardController1 SingleMarioController;
        private MarioKeyboardController2 TwoMarioController;
        private LuigiKeyboardController LuigiController;
        // set to false to skip tests
        private bool testing = true;
        private double totalTime;
        private double previousTime = 0;


        public enum GameState { MainMenu, Pause, OnePlayer, TwoPlayer };
        private GameState CurrentGameState = GameState.MainMenu;
        private GameState UnpausedGameState = GameState.OnePlayer;
        private MainMenu MainMenu;
        private PauseMenu PauseMenu;



        private void RunTests()
        {
            BlockCollisionTests blockTests = new BlockCollisionTests();
            blockTests.RunBlockTests();
            ItemCollisionTests itemTests = new ItemCollisionTests();
            itemTests.RunItemTests();
            EnemyCollisionTests enemyTests = new EnemyCollisionTests();
            enemyTests.RunEnemyTests();
        }



         public GameState getGameState()
        {
            return CurrentGameState;
        }

        public void setGameState(GameState state)
        {
            CurrentGameState = state;
        }

        public void startTheme()
        {
            soundEffect.StartTheme();
        }

        public void stopTheme()
        {
            soundEffect.StopTheme();
        }
       
        public void Pause()
        {
            UnpausedGameState = CurrentGameState;
            CurrentGameState = GameState.Pause;
            soundEffect.StopTheme();
            soundEffect.Pause();
        }

        public void UnPause()
        {
            CurrentGameState = UnpausedGameState;
            soundEffect.Pause();
            soundEffect.StartTheme();
        }

        public Sprint4()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            soundEffect = new SoundEffects();
        }

        public void Reset()
        {
            previousTime = totalTime;
            totalTime = 0;
            onePlayerLevel = OnePlayerLevelLoader.LoadLevelFromFile("OnePlayer1-1.xml", soundEffect);
            twoPlayerLevel = TwoPlayerLevelLoader.LoadLevelFromFile("TwoPlayer1-1.xml", soundEffect);
        }

        protected override void Initialize()
        {

            this.Reset();

            GameControllers = new ArrayList();
            //GameControllers.Add(new GamepadController());
            //GameControllers.Add(new KeyboardController());
            SingleMarioController = new MarioKeyboardController1();
            TwoMarioController = new MarioKeyboardController2();
            LuigiController = new LuigiKeyboardController();

            base.Initialize();

            // run tests
            if (testing)
            {
                this.RunTests();
            }
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            soundEffect = new SoundEffects();
            Sprites.SpriteFactory.loadContent(Content, SpriteBatch);
            Font = Content.Load<SpriteFont>("Instructions");
            MainMenu = new MainMenu(Font);
            MainMenu.setPosition(new Vector2(0, 0));
            PauseMenu = new PauseMenu(Font);
            PauseMenu.setPosition(new Vector2(0, 0));
    
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            switch (CurrentGameState)
            {
                case GameState.OnePlayer:
                    // update controllers
                    //foreach (IController controller in GameControllers)
                        //controller.Update(this, onePlayerLevel.mario, null);
                    SingleMarioController.Update(this, onePlayerLevel.mario);
                    break;
                default:
                    // update controllers
                    //foreach (IController controller in GameControllers)
                        //controller.Update(this, twoPlayerLevel.mario, twoPlayerLevel.luigi);
                    TwoMarioController.Update(this, twoPlayerLevel.mario);
                    LuigiController.Update(this, twoPlayerLevel.luigi);
                    break;
            }


            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    MainMenu.Update();
                    break;
                case GameState.Pause:
                    PauseMenu.Update();
                    break;
                case GameState.OnePlayer:
                    totalTime = gameTime.TotalGameTime.Seconds;
                    // update all level components
                    onePlayerLevel.Update();
                    onePlayerLevel.hud.Update(totalTime, previousTime);
                    if (onePlayerLevel.mario.getYPosition() > GraphicsDevice.Viewport.Height)
                    {
                        Reset();
                    }
                    break;
                case GameState.TwoPlayer:
                    totalTime = gameTime.TotalGameTime.Seconds;
                    // update all level components
                    twoPlayerLevel.Update();
                    twoPlayerLevel.hud.Update(totalTime, previousTime);
                    if (twoPlayerLevel.mario.getYPosition() > GraphicsDevice.Viewport.Height)
                    {
                        Reset();
                    }
                    break;
            }
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {            
            SpriteBatch.Begin();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    SpriteBatch.Draw(Content.Load<Texture2D>("Sprites/background"), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Black);
                    MainMenu.Draw(SpriteBatch);
                    break;
                case GameState.Pause:
                    SpriteBatch.Draw(Content.Load<Texture2D>("Sprites/background"), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Black);
                    PauseMenu.Draw(SpriteBatch);
                    break;
                case GameState.OnePlayer:
                    onePlayerLevel.Draw(GraphicsDevice);
                    onePlayerLevel.hud.Draw(SpriteBatch, Font, false);
                    break;
                case GameState.TwoPlayer:
                    twoPlayerLevel.Draw(GraphicsDevice);
                    twoPlayerLevel.hud.Draw(SpriteBatch, Font, true);
                    break;
            }

            SpriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
