﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_EF_project.Models
{
    public enum Sex
    {
        Male,Female
    }
    public class Worker
    {
        public int ID { get; set; }
        [Display(Name="Last Name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }

        [Display(Name="First Name")]
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }
        [Required]
        public Sex Sex { get; set; }
        public double? Rating { get; set; }//？表示可以为null
    }
}