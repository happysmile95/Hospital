using System;

namespace Hospital.Api
{
    public class PatientDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
    }
}