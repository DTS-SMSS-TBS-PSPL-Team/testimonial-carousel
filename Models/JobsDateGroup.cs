using System.ComponentModel.DataAnnotations;

namespace TS.Models
{
    public class JobsDateGroup
    {
            [DataType(DataType.Date)]
            public DateTime? applicationDate { get; set; }
            public int jobCount { get; set; }

    }
}
