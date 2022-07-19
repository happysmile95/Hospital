using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class PatientRepository : GeneralRepository, IPatientRepository
    {
        public PatientRepository(CoreContext coreContext)
            : base(coreContext)
        {
        }
    }
}
