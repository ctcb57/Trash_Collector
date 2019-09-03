using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }

    }
}