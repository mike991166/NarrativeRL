using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace NarrativeRL.Data.Factory
{
    public static class FactoryUtil
    {
        public static void InitializeFactories()
        {
            var db = new SQLiteConnection(@".\Database\nrl_db.sqlite");

            TerritoryFactory.Initialize(db);
        }

    }
}
