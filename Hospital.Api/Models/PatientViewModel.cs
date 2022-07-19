using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class PatientViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public string SiteNumber { get; set; }
    }
}
