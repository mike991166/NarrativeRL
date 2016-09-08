using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NarrativeRL.Core.Engine
{
    public interface IGameState
    {
        IGameState HandleInput(Game1 game, string input);
        void Update(Game1 game);
    }
}
