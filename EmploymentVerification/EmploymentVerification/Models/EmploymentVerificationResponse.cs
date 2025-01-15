using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentVerification.Models
{
    public class EmploymentVerificationResponse
    {
        public bool IsVerified { get; set; }
        public string Message { get; set; }
    }
}
