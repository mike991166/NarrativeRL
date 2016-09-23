using SQLite;

namespace NarrativeRL.Data.DataTypes.Narrative
{
    [Table("ListNarrativeTerrainSpecific")]
    public class NarrativeTerrainSpecific : INarrative
    {
        public int Id { get; set; }

        public string Narrative { set; get; }
    }
}
