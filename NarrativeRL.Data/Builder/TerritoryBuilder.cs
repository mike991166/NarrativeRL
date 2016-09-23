using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NarrativeRL.Data.Database;
using NarrativeRL.Data.DataTypes;
using RogueSharp.Random;
using SQLite;

namespace NarrativeRL.Data.Builder
{
    public static class TerritoryBuilder
    {
        private static bool isInitialized;

        private static List<LocationPrefix> locationPrefixes;
        private static List<Zone> zones;
        private static List<Terrain> terrains;

        public static void Initialize()
        {
            var locationPrefixQuery = DatabaseHelper.GetInstance().Table<LocationPrefix>();
            var zoneQuery = DatabaseHelper.GetInstance().Table<Zone>();
            var terrainQuery = DatabaseHelper.GetInstance().Table<Terrain>();

            locationPrefixes = locationPrefixQuery.ToList();
            zones = zoneQuery.ToList();
            terrains = terrainQuery.ToList();
            isInitialized = true;
        }

        public static Territory GetRandomTerritory(IRandom rand)
        {
            if (!isInitialized)
            {
                throw new Exception("Data not initialized.  Please call Initialize() first.");
            }

            Territory t = new Territory();

            t.LocationPrefixType = locationPrefixes.ElementAt(rand.Next(locationPrefixes.Count - 1));
            t.ZoneType = zones.ElementAt(rand.Next(zones.Count - 1));
            t.TerrainType = terrains.ElementAt(rand.Next(terrains.Count - 1));

            return t;
        }

        public static List<Territory> GetRandomTerritoryList(IRandom rand, int minCount, int maxCount)
        {
            List<Territory> territoryList = null;

            if (!isInitialized)
            {
                throw new Exception("Data not initialized.  Please call Initialize() first.");
            }
            else
            {
                Territory t; 
                int territoryCount = rand.Next(minCount, maxCount);
                territoryList = new List<Territory>();

                for (int i = 0; i < territoryCount; i++)
                {
                    t = GetRandomTerritory(rand);
                    territoryList.Add(t);
                }
            }

            return territoryList;
        }

    }
}
