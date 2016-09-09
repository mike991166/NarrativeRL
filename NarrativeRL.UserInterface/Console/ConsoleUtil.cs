using Microsoft.Xna.Framework;

namespace NarrativeRL.UserInterface.Console
{
    public static class ConsoleUtil
    {
        public static IGameComponent InitializeConsoleComponent(Game game, GraphicsDeviceManager graphics)
        {
            var sadConsoleComponent = new SadConsole.EngineGameComponent(game, graphics, "IBM.font",
                ConsoleConstants.TotalWidth, ConsoleConstants.TotalHeight,
                () =>
                {
                    SadConsole.Engine.UseMouse = true;
                    SadConsole.Engine.UseKeyboard = true;
                    SadConsole.Engine.ConsoleRenderStack.Clear();
                });

            sadConsoleComponent.Initialize();

            return sadConsoleComponent;
        }
    }
}
