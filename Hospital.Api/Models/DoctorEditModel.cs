using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class DoctorEditModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? SiteId { get; set; }
        public long ParlorId { get; set; } = -1;
        public long SpecializationId { get; set; } = -1;
    }
}
