using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    /// <summary>
    /// Специализация
    /// </summary>
    [Table("Specializations")]
    public class Specialization
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
