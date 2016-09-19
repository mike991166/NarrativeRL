using SQLite;

namespace NarrativeRL.Data.DataTypes.Narrative
{
    [Table("ListNarrativeLocationGeneral")]
    public class NarrativeLocationGeneral : INarrative
    {
        public int Id { get; set; }

        public string Narrative { set; get; }
    }
}
