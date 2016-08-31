using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NarrativeRL.Core;
using NarrativeRL.Core.Data;
using NarrativeRL.Core.Console;
using NarrativeRL.Core.Engine;
using NarrativeRL.Core.UserInterface;
using RogueSharp.Random;
using SadConsole.Consoles;
using SQLite;


namespace NarrativeRL.Core
{
    public static class GameWorld
    {
        private static Stack<IConsole> ConsoleStack;

        public static SimpleInputConsole InputConsole;

        public static MainMenuConsole MainMenu;

        public static IRandom Random { get; private set; }

        /// <summary>
        /// Called one time to initiate everything. Assumes SadConsole has been setup and is ready to go.
        /// </summary>
        public static void Start()
        {
            // initialize Console stack
            ConsoleStack = new Stack<IConsole>();

            // Establish the seed for the random number generator from the current time
            int seed = (int)DateTime.UtcNow.Ticks;
            Random = new DotNetRandom(seed);

            // initialize data
            InitializeData();

            // show main menu                       
            DisplayMainMenu();
        }

        public static void Update()
        {

        }

        private static void DisplayMainMenu()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem("[ MAIN MENU ]"));

            menuItems.Add(new MenuItem("Exit Game", (sender, e) =>
            {
                ExitSelected();
            }));

            MainMenu = new MainMenuConsole(80, 25, menuItems);
            SadConsole.Engine.ActiveConsole = MainMenu;
            SadConsole.Engine.ConsoleRenderStack.Add(MainMenu);

        }

        public static void ExitSelected()
        {
            int x = 1;
        }

        private static void InitializeData()
        {
            var db = new SQLiteConnection(@".\Database\nrl_db.sqlite");
            TerritoryFactory.Initialize(db);
        }
    }
}
