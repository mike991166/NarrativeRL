﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NarrativeRL.Core.Data;
using RogueSharp.Random;
using SQLite;

namespace NarrativeRL.Core.Engine
{
    public static class TerritoryFactory
    {
        private static bool isInitialized;

        private static List<LocationPrefix> locationPrefixes;
        private static List<Zone> zones;
        private static List<Terrain> terrains;

        public static void Initialize(SQLiteConnection db)
        {
            var locationPrefixQuery = db.Table<LocationPrefix>();
            var zoneQuery = db.Table<Zone>();
            var terrainQuery = db.Table<Terrain>();

            locationPrefixes = locationPrefixQuery.ToList();
            zones = zoneQuery.ToList();
            terrains = terrainQuery.ToList();
            isInitialized = true;
        }

        public static Territory GetTerritory(IRandom rand)
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

        public static List<Territory> GetTerritoryList(IRandom rand, int minCount, int maxCount)
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
                    t = new Territory();
                    t.LocationPrefixType = locationPrefixes.ElementAt(rand.Next(locationPrefixes.Count - 1));
                    t.ZoneType = zones.ElementAt(rand.Next(zones.Count - 1));
                    t.TerrainType = terrains.ElementAt(rand.Next(terrains.Count - 1));
                    territoryList.Add(t);
                }
            }

            return territoryList;
        }

    }
}
