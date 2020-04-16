using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.ViewModels
{
    public class UserClaimsViewModel
    {   //we.use.the.ctor.to.void.null.reference.exception.errors
        public UserClaimsViewModel()
        {
            Claims = new List<UserClaim>();
        }
        public String UserId { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}
