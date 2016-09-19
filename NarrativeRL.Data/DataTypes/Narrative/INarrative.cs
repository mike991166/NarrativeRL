using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeRL.Data.DataTypes.Narrative
{
    public interface INarrative
    {
        int Id { get; set; }

        string Narrative { set; get; }
    }
}
