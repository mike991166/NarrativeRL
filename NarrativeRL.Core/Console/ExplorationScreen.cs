using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Consoles;

namespace NarrativeRL.Core.Console
{
    public class ExplorationScreen: ConsoleList
    {
        public ExplorationHeaderConsole HeaderConsole;
        public ExplorationMainConsole MainConsole;

        public ExplorationScreen()
        {
            this.HeaderConsole = new ExplorationHeaderConsole(ConsoleConstants.TotalWidth - 2, "test"); // subtract 2 for border
            this.MainConsole = new ExplorationMainConsole(ConsoleConstants.TotalWidth - 2 - (ConsoleConstants.TotalWidth / 4),
                (ConsoleConstants.TotalHeight / 2), "This is a long narrative text value that should wrap automatically, so let's see if it does.", null);

            this.HeaderConsole.Position = new Microsoft.Xna.Framework.Point(1, 1);
            this.MainConsole.Position = new Microsoft.Xna.Framework.Point(1, 4);

            this.Add(this.HeaderConsole);
            this.Add(this.MainConsole);
        }

    }
}
