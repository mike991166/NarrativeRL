using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace NarrativeRL.Data.Builder
{
    public static class BuilderUtil
    {
        public static void InitializeBuilders()
        {
            TerritoryBuilder.Initialize();
        }
    }
}
