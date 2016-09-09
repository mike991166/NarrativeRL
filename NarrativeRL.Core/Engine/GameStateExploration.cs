using NarrativeRL.Data.DataTypes;
using NarrativeRL.UserInterface.Console;
using System;

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
            ExploreScreen.HeaderConsole.HeaderText = String.Format("{0} {1}", game.SelectedTerritory.LocationPrefixType.Name, game.SelectedTerritory.ZoneType.Name);
            ExploreScreen.SetNext(game.SelectedTerritory.TerrainType.Name, "test narrative", null);

            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ConsoleRenderStack.Add(ExploreScreen);
        }

    }
}
