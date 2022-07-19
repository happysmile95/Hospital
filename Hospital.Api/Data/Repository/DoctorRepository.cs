using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class DoctorRepository : GeneralRepository , IDoctorRepository
    {
        public DoctorRepository(CoreContext context)
            : base(context)
        {
        }
    }
}
