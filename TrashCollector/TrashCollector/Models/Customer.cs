﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Balance")]
        public double balance { get; set; }
        [Display(Name = "Pickup Day")]
        public string pickupDay { get; set; }
        [Display(Name = "Street Address")]
        public bool pickupDateSelected { get; set; }
        [Display(Name = "Special Pickup Date Selected")]
        public string individualPickupDate { get; set; }
        [Display(Name = "Individual Pickup Date")]
        public string streetAddress { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }
        [Display(Name = "User Role")]
        public string userRole { get; set; }

    }
}