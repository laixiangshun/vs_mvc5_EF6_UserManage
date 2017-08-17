using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_EF_project.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        [Required]
        [Display(Name="姓名")]
        public string userName { get; set; }

        [Required]
        [Display(Name="地址")]
        public string address { get; set; }

        [Required]
        [Display(Name="所属省")]
        public string Province { get; set; }

        [Required]
        [Display(Name="所属市")]
        public string City { get; set; }

        [Display(Name="地区代码")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name="联系号码")]
        public string phone { get; set; }
    }
}