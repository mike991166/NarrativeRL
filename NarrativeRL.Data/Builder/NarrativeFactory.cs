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

        private static List<NarrativeType> _narrativeTypes = null;

        public static INarrative GetRandomNarrative(IRandom rand, Territory territory)
        {
            INarrative n;
            int narrativeTypeId;
            int selector = rand.Next(0, 2);

            switch (selector)
            {
                case 0:
                    narrativeTypeId = GetNarrativeTypeId("General");
                    n = GetNarrative(rand, narrativeTypeId);
                    break;
                case 1:
                    narrativeTypeId = GetNarrativeTypeId("Terrain");
                    n = GetNarrative(rand, narrativeTypeId, territory.TerrainType.Id);
                    break;
                case 2:
                    narrativeTypeId = GetNarrativeTypeId("Zone");
                    n = GetNarrative(rand, narrativeTypeId, territory.ZoneType.Id);
                    break;
                default:
                    n = null;
                    break;
            };
            
            return n;
        }


        #region LEGACY DATA STRUCTURE

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

        #endregion

        public static INarrative GetNarrative(IRandom rand, int NarrativeTypeId, int ObjectId = 0)
        {
            string query = "SELECT [ListNarratives].[Id], " +
                                  "[ListNarratives].[Narrative] " +
                             "FROM [ListNarratives] " +
                       "INNER JOIN [RelObjectToNarrative] " +
                               "ON [ListNarratives].[Id] = [RelObjectToNarrative].[NarrativeId] " +
                            "WHERE [RelObjectToNarrative].[NarrativeTypeId] = ? " +
                              "AND [RelObjectToNarrative].[ObjectId] = ?";

            var result = DatabaseHelper.GetInstance().Query<NarrativeTerrainSpecific>(query, NarrativeTypeId, ObjectId);

            INarrative n = result.ElementAt(rand.Next(result.Count - 1));

            return n;
        }

        private static int GetNarrativeTypeId(string narrativeType)
        {
            int narrativeTypeId;

            if (_narrativeTypes == null)
            {
                _narrativeTypes = DatabaseHelper.GetInstance().Table<NarrativeType>().ToList();
            }

            var narrativeTypeObj = _narrativeTypes.Where(x => x.Type.Equals(narrativeType));
            narrativeTypeId = narrativeTypeObj.Single().Id;

            return narrativeTypeId;
        }
    }
}
