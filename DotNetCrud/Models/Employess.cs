using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCrud.Models
{
    public partial class Employess
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? JoiningDate { get; set; }
    }
}
