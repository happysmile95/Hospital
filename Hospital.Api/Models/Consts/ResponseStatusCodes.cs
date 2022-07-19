using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Api
{
    public class ResponseStatusCodes
    {
        public const int NotFound = 404;
        public const int InternalError = 500;
    }
}
