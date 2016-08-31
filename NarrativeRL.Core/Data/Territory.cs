using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Peanuts;

namespace NarrativeRL.Core.Data
{
    public class Territory
    {
        public int BaseLevel { set; get; }

        public LocationPrefix LocationPrefixType { set; get; }
        public Zone ZoneType { set; get; }
        public Terrain TerrainType { set; get; }


    }
}
