using NarrativeRL.UserInterface.Helper;
using SadConsole.Consoles;
using System;
using System.Collections.Generic;

namespace NarrativeRL.UserInterface.Console
{
    public class ExplorationScreen: ConsoleList
    {
        public ExplorationHeaderConsole HeaderConsole;
        public ExplorationMainConsole MainConsole;
        public ExplorationAreaDetailsConsole AreaDetailsConsole;

        public ExplorationScreen()
        {
            this.HeaderConsole = new ExplorationHeaderConsole(ConsoleConstants.TotalWidth, "test"); // subtract 2 for border
            this.MainConsole = new ExplorationMainConsole(ConsoleConstants.TotalWidth - 2 - (ConsoleConstants.TotalWidth / 4),
                (ConsoleConstants.TotalHeight / 2), "This is a long narrative text value that should wrap automatically, so let's see if it does.", null);
            this.AreaDetailsConsole = new ExplorationAreaDetailsConsole((ConsoleConstants.TotalWidth / 4) - 2, (ConsoleConstants.TotalHeight / 2), String.Empty);


            this.HeaderConsole.Position = new Microsoft.Xna.Framework.Point(0, 0);
            this.MainConsole.Position = new Microsoft.Xna.Framework.Point(1, 4);
            this.AreaDetailsConsole.Position = new Microsoft.Xna.Framework.Point(3 + this.MainConsole.Width, 4);

            this.Add(this.HeaderConsole);
            this.Add(this.MainConsole);
            this.Add(this.AreaDetailsConsole);
        }

        public void SetNext(string terrainType, string locationNarrative, List<MenuItem> menuItems)
        {
            this.AreaDetailsConsole.TerrainType = terrainType;
            this.MainConsole.NarrativeText = locationNarrative;
            this.MainConsole.MenuItems = menuItems;
        }

    }
}
