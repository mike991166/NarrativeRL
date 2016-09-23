using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NarrativeRL.Core.Engine.State;

using NarrativeRL.Data.Database;
using NarrativeRL.Data.DataTypes;
using NarrativeRL.Data.Builder;
using NarrativeRL.UserInterface;
using NarrativeRL.UserInterface.Console;
using NarrativeRL.UserInterface.Helper;

using RogueSharp.Random;

using System;
using System.Collections.Generic;

namespace NarrativeRL.Core
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public MenuConsole Menu;

        // Random Number Generator
        public IRandom Random { get; private set; }

        // Territory
        public List<Territory> TerritoryList;
        public Territory SelectedTerritory;

        // Game State
        public Stack<IGameState> GameStateStack;

        // Inputs
        public KeyboardInputHandler.InputReader InputReaderDelegate;
        public string CurrentInput;
        public Stack<MenuItem> MenuItemStack;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            #region Console
            
            var consoleComponent = ConsoleUtil.InitializeConsoleComponent(this, graphics);
            Components.Add(consoleComponent);

            // Makes the mouse visible on top of the game. Does not affect the SadConsole mouse behavior.
            IsMouseVisible = true;

            #endregion

            #region Data

            // initialize data factories
            BuilderUtil.InitializeBuilders();

            #endregion
            
            IGameState mainMenuState = new GameStateMainMenu();

            this.MenuItemStack = new Stack<MenuItem>();
            this.CurrentInput = null;

            // initialize GameState stack
            this.GameStateStack = new Stack<IGameState>();

            // Establish the seed for the random number generator from the current time
            int seed = (int)DateTime.UtcNow.Ticks;
            this.Random = new DotNetRandom(seed);

            // show main menu                       
            this.GameStateStack.Push(mainMenuState);
            this.InputReaderDelegate = GameStateStack.Peek().GetInputReader();

            //base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            DatabaseHelper.Close();
        }

        /// <summary>
        /// Allows the game to run logic ++such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            this.CurrentInput = this.InputReaderDelegate();

            // send command to processor
            // make this a function with proper error checks later
            IGameState currentGameState = this.GameStateStack.Peek();

            if (this.CurrentInput != null)
            {
                currentGameState = currentGameState.HandleInput(this, this.CurrentInput);

                // current state is exiting (we'll see how this works)
                if (currentGameState == null)
                {
                    currentGameState = this.GameStateStack.Pop(); // get next game state
                }
                else if (currentGameState != this.GameStateStack.Peek())
                {
                    this.GameStateStack.Push(currentGameState);
                }

                this.InputReaderDelegate = currentGameState.GetInputReader();
            }

            currentGameState.Update(this);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }       
    }
}
