using SQLite;

namespace NarrativeRL.Data.DataTypes.Narrative
{
    [Table("ListNarrativeTypes")]
    public class NarrativeType
    {
        public int Id { get; set; }

        public string Type { set; get; }
    }
}
