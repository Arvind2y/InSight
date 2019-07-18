using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NX_LMS.Models
{
    public class Employee
    {


        [Key]
        [Display(Name = "ID:")]
        public string Id { get; set; }

        [Display(Name = "User Name:")]
        public string UserName { get; set; }

        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name:")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Display(Name = "Full Name:")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Display(Name = "Telephone Number:")]
        public string Telephone { get; set; }

        [Display(Name = "Mobile Number:")]
        public string MobileNumber { get; set; }

        [Display(Name = "Job Title:")]
        public string JobTitle { get; set; }

        [Display(Name = "Location:")]
        public string Location { get; set; }

        [Display(Name = "Office:")]
        public string Office { get; set; }

        [Display(Name = "Department:")]
        public string Department { get; set; }

        [Display(Name = "Manager:")]
        public string Manager { get; set; }

        [Display(Name = "Company:")]
        public string Company { get; set; }

        [Display(Name = "Active :")]
        public bool? IsEnabled { get; set; }
    }
}