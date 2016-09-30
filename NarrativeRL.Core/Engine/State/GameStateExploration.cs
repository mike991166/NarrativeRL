using NarrativeRL.Data.Builder;
using NarrativeRL.Data.DataTypes.Narrative;
using NarrativeRL.UserInterface;
using NarrativeRL.UserInterface.Console;
using RogueSharp.Random;
using System;

namespace NarrativeRL.Core.Engine.State
{
    public class GameStateExploration : IGameState
    {
        private bool ExplorationScreenDisplayed = false;

        public IGameState HandleInput(Game1 game, string input)
        {
            IGameState ret = null;

            if (game.SelectedTerritory.CurrentStep == game.SelectedTerritory.TotalSteps)
            {
                ret = new GameStateTerritorySelect(); // change this to a Level End state, give experience, story, boss fight, etc...
            }
            else
            {
                // RNG decides next event type, simple for now
                int nextEventSelector = game.Random.Next(1, 1);

                switch (nextEventSelector)
                {
                    case 1:
                        ret = new GameStateDisplayNarrative();
                        break;
                    default:
                        ret = null;
                        break;
                }

                // increment steps
                game.SelectedTerritory.CurrentStep += 1;
            }

            return ret;
        }

        public void Update(Game1 game)
        {                     
            // null
        }

        public KeyboardInputHandler.InputReader GetInputReader()
        {
            return KeyboardInputHandler.GenerateKey;
        }               
    }
}
