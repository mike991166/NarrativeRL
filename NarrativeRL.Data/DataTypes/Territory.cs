namespace NarrativeRL.Data.DataTypes
{
    public class Territory
    {
        public int BaseLevel { set; get; }

        public int TotalSteps { set; get; }
        public int CurrentStep { set; get; }

        public LocationPrefix LocationPrefixType { set; get; }
        public Zone ZoneType { set; get; }
        public Terrain TerrainType { set; get; }
    }
}
