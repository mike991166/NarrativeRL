using NarrativeRL.Data.DataTypes;
using NarrativeRL.Data.Builder;
using NarrativeRL.UserInterface;
using NarrativeRL.UserInterface.Console;
using NarrativeRL.UserInterface.Helper;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NarrativeRL.Core.Engine.State
{
    public class GameStateTerritorySelect : IGameState
    {
        private bool TerritorySelectDisplayed = false;

        public IGameState HandleInput(Game1 game, string input)
        {
            IGameState ret;
            int intValue = int.Parse(input);

            switch (intValue)
            {
                case ConsoleConstants.TerritorySelectGetMoreTerritories:
                    ret = this;
                    this.TerritorySelectDisplayed = false;
                    break;
                default:
                    game.SelectedTerritory = game.TerritoryList.ElementAt(intValue - 1);
                    this.TerritorySelectDisplayed = false;
                    ret = new GameStateTerritoryIntro();
                    break;
            }

            return ret;
        }

        public void Update(Game1 game)
        {
            if (!TerritorySelectDisplayed)
            {
                this.ShowTerritorySelectionScreen(game);
                this.TerritorySelectDisplayed = true;
            }
        }

        public KeyboardInputHandler.InputReader GetInputReader()
        {
            return KeyboardInputHandler.ReadLineFromKeyboard;
        }

        public void ShowTerritorySelectionScreen(Game1 game)
        {
            string title, introduction;

            // clear existing menu        
            SadConsole.Engine.ConsoleRenderStack.Clear();

            title = "[ SELECT A TERRITORY TO EXPLORE ]";
            introduction = String.Empty;

            // get list of territories
            game.TerritoryList = TerritoryBuilder.GetRandomTerritoryList(game.Random, 3, 9);

            // build territory menu items
            string territoryString;
            Territory t;

            List<MenuItem> menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem("Get More Territories", 0, null));

            for (int i = 0; i < game.TerritoryList.Count; i++)
            {
                t = game.TerritoryList.ElementAt(i);
                territoryString = String.Format("{0} {1} [{2}]", t.LocationPrefixType.Name, t.ZoneType.Name, t.TerrainType.Name);

                menuItems.Add(new MenuItem(territoryString, i, null));
            }

            // add to menu
            MenuConsole Menu = new MenuConsole(ConsoleConstants.TotalWidth, ConsoleConstants.TotalHeight, title, introduction, menuItems);
            SadConsole.Engine.ActiveConsole = Menu;
            SadConsole.Engine.ConsoleRenderStack.Add(Menu);
        }
    }
}
