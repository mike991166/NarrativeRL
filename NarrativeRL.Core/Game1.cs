using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

using NarrativeRL.Core.Console;
using NarrativeRL.Core.Data;
using NarrativeRL.Core.Engine;

using SQLite;

namespace NarrativeRL.Core
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameTime LastInputProcessedTime;
        StringBuilder InputKeys;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            LastInputProcessedTime = new GameTime();
            InputKeys = new StringBuilder();
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

            #region SadConsole

            var sadConsoleComponent = new SadConsole.EngineGameComponent(this, graphics, "IBM.font", 
                ConsoleConstants.TotalWidth, ConsoleConstants.TotalHeight, 
                () =>
                    {
                        SadConsole.Engine.UseMouse = true;
                        SadConsole.Engine.UseKeyboard = true;

                        var sampleConsole = new SadConsole.Consoles.Console(80, 60);
                        //sampleConsole.FillWithRandomGarbage();

                        SadConsole.Engine.ConsoleRenderStack.Clear();
                        SadConsole.Engine.ConsoleRenderStack.Add(sampleConsole);
                        SadConsole.Engine.ActiveConsole = sampleConsole;

                    });

            Components.Add(sadConsoleComponent);

            // Makes the mouse visible on top of the game. Does not affect the SadConsole mouse behavior.
            IsMouseVisible = true;

            #endregion

            #region SQLite

            var db = new SQLiteConnection(@".\Database\nrl_db.sqlite");

            #endregion

            base.Initialize();

            GameWorld.Start();
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


            // Process Received Input, waiting on Enter key
            SadConsole.Input.KeyboardInfo keyInfo = SadConsole.Engine.Keyboard;

            if (keyInfo.KeysReleased.Count > 0)
            {
                if (keyInfo.IsKeyReleased(Keys.Enter))
                {
                    string enteredString = this.InputKeys.ToString();
                    this.InputKeys.Clear();
                }
                else
                {
                    this.InputKeys.Append(keyInfo.KeysReleased[0].Character);
                }
            }
           
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
