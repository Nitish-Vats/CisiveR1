using EmploymentVerification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentVerification.InMemoryData
{
    public class EmployeeDataBase
    {
        private static readonly List<Employee> _employees = new()
        {
            new Employee { EmployeeId = 1001, CompanyName = "Cisive Solutions", VerificationCode = "CS1001" },
            new Employee { EmployeeId = 1002, CompanyName = "Tech Mahindra", VerificationCode = "TM1002" },
            new Employee { EmployeeId = 1003, CompanyName = "Infosys Limited", VerificationCode = "IL1003" }
        };

        public Employee GetEmployee(int employeeId, string companyName)
        {
            return _employees.Find(e =>
                e.EmployeeId == employeeId &&
                e.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
