using NarrativeRL.UserInterface.Console;
using System;

namespace NarrativeRL.Core.Engine.State
{
    class GameStateTerritoryIntro : IGameState
    {
        private bool ExplorationIntroScreenDisplayed = false;

        public IGameState HandleInput(Game1 game, string input)
        {
            IGameState ret;

            switch (input)
            {
                default:
                    ret = new GameStateExploration();
                    break;
            }

            return ret;
        }

        public void Update(Game1 game)
        {
            if (!ExplorationIntroScreenDisplayed)
            {
                this.ShowExplorationIntroScreen(game);
                this.ExplorationIntroScreenDisplayed = true;
            }
        }

        public InputUtil.InputReader GetInputReader()
        {
            return InputUtil.ReadAnyKeyFromKeyboard;
        }

        public void ShowExplorationIntroScreen(Game1 game)
        {
            ExplorationScreen ExploreScreen = new ExplorationScreen();
            ExploreScreen.HeaderConsole.HeaderText = String.Format("{0} {1}", game.SelectedTerritory.LocationPrefixType.Name, game.SelectedTerritory.ZoneType.Name);
            ExploreScreen.SetNext(game.SelectedTerritory.TerrainType.Name, game.SelectedTerritory.ZoneType.Description, null);

            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ConsoleRenderStack.Add(ExploreScreen);
        }
    }
}
