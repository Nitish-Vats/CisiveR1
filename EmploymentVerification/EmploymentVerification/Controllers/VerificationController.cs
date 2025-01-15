using EmploymentVerification.InMemoryData;
using EmploymentVerification.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentVerification.Controllers
{
    [ApiController]
    [Route("api")]
    public class VerificationController : Controller
    {
        private readonly EmployeeDataBase _database;

        public VerificationController()
        {
            _database = new EmployeeDataBase();
        }

        [HttpPost("verify-employment")]
        public ActionResult<EmploymentVerificationResponse> VerifyEmployment([FromBody] EmploymentVerificationRequest request)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(new EmploymentVerificationResponse
                {
                    IsVerified = false,
                    Message = "Invalid input data"
                });
            }

          
            var employee = _database.GetEmployee(request.EmployeeId, request.CompanyName);

          
            if (employee == null)
            {
                return NotFound(new EmploymentVerificationResponse
                {
                    IsVerified = false,
                    Message = "Employee not found"
                });
            }

            bool isVerified = employee.VerificationCode.Equals(
                request.VerificationCode,
                StringComparison.OrdinalIgnoreCase
            );

            return Ok(new EmploymentVerificationResponse
            {
                IsVerified = isVerified,
                Message = isVerified ? "Employment verified successfully" : "Invalid verification code"
            });
        }

    }
}
