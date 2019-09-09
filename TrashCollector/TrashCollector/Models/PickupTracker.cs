using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class PickupTracker
    {
        [Key]
        public int pickupId { get; set; }

        [Display(Name ="Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime? pickupDate { get; set; }

        [ForeignKey("Employee")]
        public int employeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Customer")]
        public int customerId { get; set; }
        public Customer Customer { get; set; }
    }
}