using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeRL.Core.Engine
{
    public class GameStateExitGame : IGameState
    {
        public IGameState HandleInput(Game1 game, string input)
        {
            // update to check if user wants to exit.
            return this;
        }

        public void Update(Game1 game)
        {
            game.Exit();
        }
    }
}
