using SQLite;

namespace NarrativeRL.Data.DataTypes.Narrative
{
    [Table("ListNarrativeZoneSpecific")]
    public class NarrativeZoneSpecific : INarrative
    {
        public int Id { get; set; }

        public string Narrative { set; get; }
    }
}
