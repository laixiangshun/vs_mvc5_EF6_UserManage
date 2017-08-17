using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_EF_project.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int provinceId { get; set; }
    }
}