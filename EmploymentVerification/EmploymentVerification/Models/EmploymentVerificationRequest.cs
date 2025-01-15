using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentVerification.Models
{
    public class EmploymentVerificationRequest
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string VerificationCode { get; set; }
    }
}
