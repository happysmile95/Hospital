using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    /// <summary>
    /// Пациент
    /// </summary>
    [Table("Patients")]
    public class Patient
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// Пол (false муж. ,true жен.)
        /// </summary>
        public bool Gender { get; set; }

        public Site Site { get; set; }
        public long? SiteId { get; set; }
    }
}
