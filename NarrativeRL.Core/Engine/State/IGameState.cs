﻿using NarrativeRL.UserInterface;

namespace NarrativeRL.Core.Engine.State
{
    public interface IGameState
    {
        IGameState HandleInput(Game1 game, string input);

        void Update(Game1 game);

        KeyboardInputHandler.InputReader GetInputReader();
    }
}
