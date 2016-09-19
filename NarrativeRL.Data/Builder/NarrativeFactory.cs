using NarrativeRL.Data.DataTypes.Narrative;
using RogueSharp.Random;
using SQLite;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NarrativeRL.Data.Builder
{
    public static class NarrativeFactory
    {
        private static bool isInitialized = false;
        private static List<NarrativeLocationGeneral> narrativesLocationGeneral;

        public static void Initialize(SQLiteConnection db)
        {
            var narrativeLocationGeneralQuery = db.Table<NarrativeLocationGeneral>();
            narrativesLocationGeneral = narrativeLocationGeneralQuery.ToList();
            isInitialized = true;
        }

        public static INarrative GetRandomNarrative(IRandom rand)
        {
            if (!isInitialized)
            {
                throw new Exception("Data not initialized.  Please call Initialize() first.");
            }

            INarrative n = narrativesLocationGeneral.ElementAt(rand.Next(narrativesLocationGeneral.Count - 1));
#if DEBUG
            n.Narrative = String.Format("GENERAL - {0}", n.Narrative);
#endif
            return n;
        }


    }
}
