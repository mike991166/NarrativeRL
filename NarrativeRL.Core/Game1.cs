using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using NarrativeRL.Core.Engine;
using NarrativeRL.Data.DataTypes;
using NarrativeRL.Data.Builder;
using NarrativeRL.UserInterface.Console;

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

        public IRandom Random { get; private set; }

        public List<Territory> TerritoryList;
        public Territory SelectedTerritory;

        public Stack<IGameState> GameStateStack;
        public string CurrentInput;



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
            CurrentInput = null;

            // initialize GameState stack
            GameStateStack = new Stack<IGameState>();

            // Establish the seed for the random number generator from the current time
            int seed = (int)DateTime.UtcNow.Ticks;
            Random = new DotNetRandom(seed);

            // show main menu                       
            GameStateStack.Push(mainMenuState);

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
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            this.CurrentInput = InputUtil.ReadLineFromKeyboard();

            // send command to processor
            // make this a function with proper error checks later
            IGameState currentGameState = this.GameStateStack.Peek();

            if (!String.IsNullOrWhiteSpace(this.CurrentInput))
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
