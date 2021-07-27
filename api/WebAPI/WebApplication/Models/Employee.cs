using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Departament { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }

    }
}
