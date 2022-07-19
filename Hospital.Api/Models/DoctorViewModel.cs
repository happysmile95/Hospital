using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class DoctorViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ParlorNumber { get; set; }
        public int? SiteNumber { get; set; }
        public string Specialization { get; set; }
    }
}
