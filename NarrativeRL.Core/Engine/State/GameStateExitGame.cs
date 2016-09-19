namespace NarrativeRL.Core.Engine.State
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

        public InputUtil.InputReader GetInputReader()
        {
            return InputUtil.ReadAnyKeyFromKeyboard;
        }
    }
}
