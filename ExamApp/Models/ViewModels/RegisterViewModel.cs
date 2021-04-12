﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter a User Name")]
        [Display(Name = "User Name")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Please Enter Full Name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter a Password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Do Not Match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Please Enter the Phone Number of C&F Agent")]
        public string PhoneNumber { get; set; }


        //public int GateId { get; set; }

        //public int YardId { get; set; }

        //public int UserTypeId { get; set; }
    }
}
