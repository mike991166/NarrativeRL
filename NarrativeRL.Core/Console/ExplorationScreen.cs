using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Consoles;
using RogueSharp.Random;

using NarrativeRL.Core.Data;
using NarrativeRL.Core.Engine;
using NarrativeRL.Core.UserInterface;

namespace NarrativeRL.Core.Console
{
    public class ExplorationScreen: ConsoleList
    {
        public ExplorationHeaderConsole HeaderConsole;
        public ExplorationMainConsole MainConsole;
        public ExplorationAreaDetailsConsole AreaDetailsConsole;

        public ExplorationScreen()
        {
            Territory t = TerritoryFactory.GetTerritory(new DotNetRandom((int)DateTime.UtcNow.Ticks));

            this.HeaderConsole = new ExplorationHeaderConsole(ConsoleConstants.TotalWidth, "test"); // subtract 2 for border
            this.MainConsole = new ExplorationMainConsole(ConsoleConstants.TotalWidth - 2 - (ConsoleConstants.TotalWidth / 4),
                (ConsoleConstants.TotalHeight / 2), "This is a long narrative text value that should wrap automatically, so let's see if it does.", null);
            this.AreaDetailsConsole = new ExplorationAreaDetailsConsole((ConsoleConstants.TotalWidth / 4) - 2, (ConsoleConstants.TotalHeight / 2), t);


            this.HeaderConsole.Position = new Microsoft.Xna.Framework.Point(0, 0);
            this.MainConsole.Position = new Microsoft.Xna.Framework.Point(1, 4);
            this.AreaDetailsConsole.Position = new Microsoft.Xna.Framework.Point(3 + this.MainConsole.Width, 4);

            this.Add(this.HeaderConsole);
            this.Add(this.MainConsole);
            this.Add(this.AreaDetailsConsole);
        }

        public void SetNext(Territory territory, string locationNarrative, List<MenuItem> menuItems)
        {
            this.AreaDetailsConsole.CurrentTerritory = territory;
            this.MainConsole.NarrativeText = locationNarrative;
            this.MainConsole.MenuItems = menuItems;
        }

    }
}
