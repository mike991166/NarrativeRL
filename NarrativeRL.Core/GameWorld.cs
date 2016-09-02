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
        public static MenuConsole Menu;

        public static IRandom Random { get; private set; }

        public static List<Territory> TerritoryList;



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

            menuItems.Add(new MenuItem("New Game", (sender, e) =>
            {
                NewGameSelected();
            }));

            menuItems.Add(new MenuItem("Exit Game", (sender, e) =>
            {
                ExitSelected();
            }));

            

            Menu = new MenuConsole(80, 25, menuItems);
            SadConsole.Engine.ActiveConsole = Menu;
            SadConsole.Engine.ConsoleRenderStack.Add(Menu);

        }

        public static void NewGameSelected()
        {
            // clear existing menu        
            SadConsole.Engine.ConsoleRenderStack.Clear();

            // get list of territories
            TerritoryList = TerritoryFactory.GetTerritoryList(Random, 3, 9);

            // build territory menu items
            string territoryString;
            Territory t;

            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem("[ SELECT A TERRITORY TO EXPLORE ]"));

            menuItems.Add(new MenuItem("Get More Territories", (sender, e) =>
            {
                NewGameSelected();
            }));

            for (int i = 0; i < TerritoryList.Count; i++)
            {
                t = TerritoryList.ElementAt(i);
                territoryString = String.Format("{0} {1} [{2}]", t.LocationPrefixType.Name, t.ZoneType.Name, t.TerrainType.Name);

                menuItems.Add(new MenuItem(territoryString, (sender, e) =>
                {
                    TerritorySelected(i);
                }));
            }

            // add to menu
            Menu = new MenuConsole(80, 25, menuItems);
            SadConsole.Engine.ActiveConsole = Menu;
            SadConsole.Engine.ConsoleRenderStack.Add(Menu);
        }

        public static void TerritorySelected(int SelectedTerritory)
        {
            int x = 1;
        }

        public static void ExitSelected()
        {
            Environment.Exit(0);
        }

        private static void InitializeData()
        {
            var db = new SQLiteConnection(@".\Database\nrl_db.sqlite");
            TerritoryFactory.Initialize(db);
        }
    }
}
