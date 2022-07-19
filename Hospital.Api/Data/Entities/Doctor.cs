using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    /// <summary>
    /// Врач
    /// </summary>
    [Table("Doctors")]
    public class Doctor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public Parlor Parlor { get; set; }
        public long? ParlorId { get; set; }

        public Specialization Specialization { get; set; }
        public long? SpecializationId { get; set; }

        public Site Site { get; set; }
        public long? SiteId { get; set; }
    }
}
