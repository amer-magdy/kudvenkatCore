using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.Security
{   //we.need.to.inherit.from.IAuthorizationRequirmenet
    public class ManageAdminRolesAndClaimsRequirement : IAuthorizationRequirement
    {

    }
}
