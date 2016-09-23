using NarrativeRL.Data.Database;
using NarrativeRL.Data.DataTypes;
using NarrativeRL.Data.DataTypes.Narrative;
using RogueSharp.Random;
using System.Collections.Generic;
using System.Linq;

namespace NarrativeRL.Data.Builder
{
    public static class NarrativeFactory
    {
        private static List<NarrativeLocationGeneral> _narrativesLocationGeneral;

        public static INarrative GetRandomNarrative(IRandom rand, Territory territory)
        {
            INarrative n;
            int selector = rand.Next(0, 2);

            switch (selector)
            {
                case 0:
                    n = GetRandomNarrativeLocationGeneral(rand);
                    break;
                case 1:
                    n = GetRandomNarrativeTerrainSpecific(rand, territory.TerrainType);
                    break;
                case 2:
                    n = GetRandomNarrativeZoneSpecific(rand, territory.ZoneType);
                    break;
                default:
                    n = null;
                    break;
            };
            
            return n;
        }

        public static INarrative GetRandomNarrativeLocationGeneral(IRandom rand)
        {
            if (_narrativesLocationGeneral == null)
            {
                var narrativeLocationGeneralQuery = DatabaseHelper.GetInstance().Table<NarrativeLocationGeneral>();
                _narrativesLocationGeneral = narrativeLocationGeneralQuery.ToList();
            }

            INarrative n = _narrativesLocationGeneral.ElementAt(rand.Next(_narrativesLocationGeneral.Count - 1));

            return n;
        }

        public static INarrative GetRandomNarrativeTerrainSpecific(IRandom rand, Terrain terrain)
        {
            string query = "SELECT [ListNarrativeTerrainSpecific].[Id], " +
                                  "[ListNarrativeTerrainSpecific].[Narrative] " +
                             "FROM [ListNarrativeTerrainSpecific] " +
                       "INNER JOIN [RelTerrainToNarrativeTerrainSpecific] " +
                               "ON [ListNarrativeTerrainSpecific].[Id] = [RelTerrainToNarrativeTerrainSpecific].[NarrativeTerrainSpecificId] " +
                            "WHERE [RelTerrainToNarrativeTerrainSpecific].[TerrainId] = ?";

            var result = DatabaseHelper.GetInstance().Query<NarrativeTerrainSpecific>(query, terrain.Id);

            INarrative n = result.ElementAt(rand.Next(result.Count - 1));

            return n;
        }

        public static INarrative GetRandomNarrativeZoneSpecific(IRandom rand, Zone zone)
        {
            string query = "SELECT [ListNarrativeZoneSpecific].[Id], " +
                                  "[ListNarrativeZoneSpecific].[Narrative] " +
                             "FROM [ListNarrativeZoneSpecific] " +
                       "INNER JOIN [RelZoneToNarrativeZoneSpecific] " +
                               "ON [ListNarrativeZoneSpecific].[Id] = [RelZoneToNarrativeZoneSpecific].[NarrativeZoneSpecificId] " +
                            "WHERE [RelZoneToNarrativeZoneSpecific].[ZoneId] = ?";
          
            var result = DatabaseHelper.GetInstance().Query<NarrativeTerrainSpecific>(query, zone.Id);

            INarrative n = result.ElementAt(rand.Next(result.Count - 1));

            return n;
        }
    }
}
