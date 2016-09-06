using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarrativeRL.Core.Data;
using SadConsole.Consoles;

namespace NarrativeRL.Core.Console
{
    public class ExplorationAreaDetailsConsole: BorderedConsole
    {
        public Territory CurrentTerritory;

        public ExplorationAreaDetailsConsole(int width, int height) : base(width, height) { }

        public ExplorationAreaDetailsConsole(int width, int height, Territory territory) : base(width, height)
        {
            this.CurrentTerritory = territory;
        }

        public override void Render()
        {
            base.Render();

            Cursor consoleCursor = new Cursor(this);
            consoleCursor.Print(this.CurrentTerritory.TerrainType.Name);
        }
    }
}
