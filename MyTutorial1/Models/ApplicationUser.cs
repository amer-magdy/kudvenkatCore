using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.Models
{   //to.make.replace.for.every.class.use.IdentityUser.right.click.on.the.var.and.choose.findAllReference
    //if.there,is.also.another,elemenet.use.the.same.class.press.ctrl+shift+f.and.search.make.sure.that.search.entire.solution
    //if.we.make.add-migration.cannot.added.successfully.we.need.to.open.appDbContext.class
    //and.make.this.line.public class AppDbContext : IdentityDbContext<ApplicationUser>
    public class ApplicationUser: IdentityUser
    {   //add.Custom.column.in.ASPUser.Table
        public String City { get; set; }
    }
}
