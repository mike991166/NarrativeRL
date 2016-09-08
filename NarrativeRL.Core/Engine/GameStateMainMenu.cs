using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using NarrativeRL.Core.Console;
using NarrativeRL.Core.UserInterface;

namespace NarrativeRL.Core.Engine
{
    public class GameStateMainMenu : IGameState
    {
        private MenuConsole Menu;
        private bool MainMenuDisplayed = false;

        public IGameState HandleInput(Game1 game, string input)
        {
            IGameState ret;
            int intValue = int.Parse(input);

            switch (intValue)
            {
                case ConsoleConstants.MainMenuNewGame:
                    ret = new GameStateTerritorySelect();
                    break;
                case ConsoleConstants.MainMenuExit:
                    ret = new GameStateExitGame();
                    this.MainMenuDisplayed = false;
                    break;
                default:
                    ret = this;
                    break;
            }


            return ret;

        }

        public void Update(Game1 game)
        {
            if (!MainMenuDisplayed)
            {
                this.DisplayMainMenu();
                this.MainMenuDisplayed = true;
            }
        }

        private void DisplayMainMenu()
        {
            string title, introduction;
            List<MenuItem> menuItems = new List<MenuItem>();

            title = "[ MAIN MENU ]";
            introduction = "<CATCH PHRASE>";

            menuItems.Add(new MenuItem("New Game", ConsoleConstants.MainMenuNewGame, null));
            menuItems.Add(new MenuItem("Exit Game", ConsoleConstants.MainMenuExit, null));

            Menu = new MenuConsole(ConsoleConstants.TotalWidth, ConsoleConstants.TotalHeight,
                title, introduction, menuItems);
            SadConsole.Engine.ActiveConsole = Menu;
            SadConsole.Engine.ConsoleRenderStack.Add(Menu);

        }
    }
}
