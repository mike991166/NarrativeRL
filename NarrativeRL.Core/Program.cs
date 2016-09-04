//using System;

//namespace NarrativeRL.Core
//{
//#if WINDOWS || LINUX
//    /// <summary>
//    /// The main class.
//    /// </summary>
//    public static class Program
//    {
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            using (var game = new Game1())
//                game.Run();

//        }
//#endif
//    }
//}

using System;
using Console = SadConsole.Consoles.Console;
using SadConsole.Consoles;
using Microsoft.Xna.Framework;

using NarrativeRL.Core.Data;

using SQLite;
using NarrativeRL.Core.Console;

namespace NarrativeRL.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SQLite

            var db = new SQLiteConnection(@".\Database\nrl_db.sqlite");

            #endregion

            // Initialize ECS
            Peanuts.Peanuts.Initialize();

            // Setup the engine and creat the main window.
            //SadConsole.Engine.Initialize("IBM.font", 80, 25);
            //SadConsole.Engine.Initialize("CGA8x8thick.font", 80, 60);
            SadConsole.Engine.Initialize("IBM.font", ConsoleConstants.TotalWidth, ConsoleConstants.TotalHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Engine.EngineStart += Engine_EngineStart;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Engine.EngineUpdated += Engine_EngineUpdated;

            // Start the game.
            SadConsole.Engine.Run();
        }

        private static void Engine_EngineStart(object sender, EventArgs e)
        {
            // Clear the default console
            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ActiveConsole = null;

            GameWorld.Start();
        }

        private static void Engine_EngineUpdated(object sender, EventArgs e)
        {
            int x = 1;
        }
    }
}