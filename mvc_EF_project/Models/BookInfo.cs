using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_EF_project.Models
{
    public class BookInfo
    {
        public int Id { get; set; }

        public string Number { get; set; }

        [StringLength(60,MinimumLength=1)]
        public string Name { get; set; }

        public string Author { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public bool Deleted { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd HH:mm:ss}",ApplyFormatInEditMode=true)]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Text)]
        [StringLength(20,MinimumLength=1)]
        public String yuyan { get; set; }
    }
}