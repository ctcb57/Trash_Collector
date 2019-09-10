using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int customerId { get; set; }
        [Display(Name ="First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Balance")]
        public double balance { get; set; }
        [Display(Name = "Pickup Confirmation")]
        public bool pickupConfirmed { get; set; }
        [Display(Name = "Pickup Day")]
        public string pickupDay { get; set; }
        [Display(Name = "One-Time Pickup Date")]
        [DataType(DataType.Date)]
        public DateTime? specialPickupDate { get; set; }
        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }
        public double longitute { get; set; }
        public double latitude { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }
        [Display(Name = "State Abbreviation")]
        public string stateAbbreviation { get; set; }
        [Display(Name = "Account Suspension Start Date")]
        [DataType(DataType.Date)]
        public DateTime? AccountSuspensionStartDate { get; set; }
        [Display(Name = "Account Suspension End Date")]
        [DataType(DataType.Date)]
        public DateTime? AccountSuspensionEndDate { get; set; }
        [Display(Name = "User Role")]

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public enum DayOfWeek { }

    }
}