using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NarrativeRL.Core.Console;


namespace NarrativeRL.Core.Engine
{
    public class GameStateExploration : IGameState
    {
        private bool ExplorationScreenDisplayed = false;

        public IGameState HandleInput(Game1 game, string input)
        {
            IGameState ret;

            switch (input)
            {
                default:
                    ret = this;
                    this.ExplorationScreenDisplayed = false;
                    break;
            }

            return ret;
        }

        public void Update(Game1 game)
        {
            if (!ExplorationScreenDisplayed)
            {
                this.ShowExplorationScreen(game);
                this.ExplorationScreenDisplayed = true;
            }
        }

        public void ShowExplorationScreen(Game1 game)
        {
            ExplorationScreen ExploreScreen = new ExplorationScreen();
            ExploreScreen.SetNext(game.SelectedTerritory, "test narrative", null);

            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ConsoleRenderStack.Add(ExploreScreen);
        }

    }
}
