using SQLite;

namespace NarrativeRL.Data.DataTypes.Narrative
{
    [Table("ListNarratives")]
    public class Narratives
    {
        public int Id { get; set; }

        public string Narrative { set; get; }
    }
}
