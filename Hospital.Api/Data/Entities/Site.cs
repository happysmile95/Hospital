using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    /// <summary>
    /// Участок
    /// </summary>
    [Table("Sites")]
    public class Site
    {
        public long Id { get; set; }
        public int Number { get; set; }

        public ICollection<Patient> Patients { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
