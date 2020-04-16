using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<String>();
            Roles = new List<String>();
        }

        public String Id { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        public String City { get; set; }
        //we.use.thus.for.any.null.reference.exception.errors   ;)
        public List<String> Claims { get; set; }
        //Notice:that.Roles.Used>ILIST
        public IList<String> Roles { get; set; }
    }
}
