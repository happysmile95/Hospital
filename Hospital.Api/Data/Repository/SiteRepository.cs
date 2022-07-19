using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class SiteRepository : GeneralRepository, ISiteRepository
    {
        public SiteRepository(CoreContext context)
            : base(context)
        {
        }
    }
}
