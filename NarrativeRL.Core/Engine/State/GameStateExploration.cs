using NarrativeRL.Data.Builder;
using NarrativeRL.Data.DataTypes.Narrative;
using NarrativeRL.UserInterface.Console;
using System;

namespace NarrativeRL.Core.Engine.State
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

        public InputUtil.InputReader GetInputReader()
        {
            return InputUtil.ReadAnyKeyFromKeyboard;
        }

        public void ShowExplorationScreen(Game1 game)
        {
            // logic to get narratives, events, battle, etc. will be called from here.
            INarrative narrative = NarrativeFactory.GetRandomNarrative(game.Random);

            ExplorationScreen ExploreScreen = new ExplorationScreen();
            ExploreScreen.HeaderConsole.HeaderText = String.Format("{0} {1}", game.SelectedTerritory.LocationPrefixType.Name, game.SelectedTerritory.ZoneType.Name);
            ExploreScreen.SetNext(game.SelectedTerritory.TerrainType.Name, narrative.Narrative, null);

            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ConsoleRenderStack.Add(ExploreScreen);
        }

    }
}
