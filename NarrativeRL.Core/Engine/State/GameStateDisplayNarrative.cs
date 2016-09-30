using NarrativeRL.Data.Builder;
using NarrativeRL.Data.DataTypes.Narrative;
using NarrativeRL.UserInterface;
using NarrativeRL.UserInterface.Console;
using System;

namespace NarrativeRL.Core.Engine.State
{
    public class GameStateDisplayNarrative : IGameState
    {
        private bool NarrativeScreenDisplayed = false;

        public IGameState HandleInput(Game1 game, string input)
        {
            IGameState ret;

            // Any Key is valid
            switch (input)
            {
                default:
                    ret = new GameStateExploration();
                    this.NarrativeScreenDisplayed = false;
                    break;
            }

            return ret;
        }

        public void Update(Game1 game)
        {
            if (!NarrativeScreenDisplayed)
            {
                this.ShowNarrativeScreen(game);
                this.NarrativeScreenDisplayed = true;
            }
        }

        public KeyboardInputHandler.InputReader GetInputReader()
        {
            return KeyboardInputHandler.ReadAnyKeyFromKeyboard;
        }

        public void ShowNarrativeScreen(Game1 game)
        {
            INarrative narrative = NarrativeFactory.GetRandomNarrative(game.Random, game.SelectedTerritory);

            ExplorationScreen ExploreScreen = new ExplorationScreen();

            ExploreScreen.HeaderConsole.HeaderText = String.Format("{0} {1}", game.SelectedTerritory.LocationPrefixType.Name, game.SelectedTerritory.ZoneType.Name);
            ExploreScreen.HeaderConsole.TotalSteps = game.SelectedTerritory.TotalSteps;
            ExploreScreen.HeaderConsole.CurrentStep = game.SelectedTerritory.CurrentStep; // increment in main loop

            ExploreScreen.SetNext(game.SelectedTerritory.TerrainType.Name, narrative.Narrative, null);

            SadConsole.Engine.ConsoleRenderStack.Clear();
            SadConsole.Engine.ConsoleRenderStack.Add(ExploreScreen);
        }
    }
}
