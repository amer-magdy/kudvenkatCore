using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.Utilities
{   //Custom.validation.attribute
    public class ValidEmailDomainAttribute: ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(String allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        //the.value.is.coming.from.email.input.field
        public override bool IsValid(object value)
        {
            //convert.from.object.to.string
            //Strings.has.two.values.first.is.what.is.before@.and.second.is.what.is.after@
            String[] Strings = value.ToString().Split('@');
            return Strings[1].ToUpper() == allowedDomain.ToUpper();
        }






    }
}
