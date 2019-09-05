﻿using System;
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
        [Display(Name = "Pickup Day")]
        public string pickupDay { get; set; }
        [Display(Name = "Pickup Date Selected?")]
        public bool pickupDateSelected { get; set; }
        [Display(Name = "Pickup Date Selected")]
        public DateTime Date { get; set; }
        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }
        [Display(Name = "User Role")]

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public enum DayOfWeek { }

    }
}