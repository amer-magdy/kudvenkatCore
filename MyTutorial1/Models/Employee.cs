using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.Models
{
    public class Employee
        //this.is.all.functions.we.can.use
        //Required.Range.StringLength.Compare.RegularExpression,etc{Bulit.in.validation.att}
    {   //prob + two times tabs to create get and set
        public int Id { get; set; }        
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Display(Name = "Office Email")]        
        [Required]
        //[EmailAddress]
        public String Email { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed more than 50 characters")]
        [MinLength(2, ErrorMessage = "Name cannot be less than 2 characters")]
        public String Name { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public String PhotoPath { get; set; }
        
    }
}
