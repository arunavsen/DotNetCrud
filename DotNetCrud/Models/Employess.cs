using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name ="Joining Date")]
        public DateTime? JoiningDate { get; set; }
    }
}
