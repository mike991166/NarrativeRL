using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NarrativeRL.Core.Data;
using NarrativeRL.Core.Engine;
using RogueSharp.Random;

namespace NarrativeRL.Core.Console
{
    public class OverworldConsole : SadConsole.Consoles.Console
    {
        public OverworldConsole(int Width, int Height, uint MaxNumberOfTerritoriesToFetch, IRandom Rng) : base(Width, Height)
        {
            Territory t;
            int baseHeight = 2;
            int NumberOfTerritories = Rng.Next(2, (int)MaxNumberOfTerritoriesToFetch);

            for (int i = 0; i < NumberOfTerritories; i++)
            {
                t = TerritoryFactory.GetTerritory(Rng);
                this.Print(2, (baseHeight + (i * 2)), String.Format("{0} {1} [{2}]", t.LocationPrefixType.Name, t.ZoneType.Name, t.TerrainType.Name));
            }
        }

    }
}
