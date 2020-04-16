using Microsoft.AspNetCore.Mvc;
using MyTutorial1.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        //To.response.immediately.for.user.by.returning.json.and.its.work.by.ajax.must.installed.jquery-validate.and.jquery-validation-unobtrusive
        [Remote(controller: "Account", action: "IsEmailInUse")]
        //Custom.validation.error.message.by.utilities.validEmailDOmainAttribute
        [ValidEmailDomain(allowedDomain:"pragim.com",ErrorMessage =
            "Email Domain Must Be pragim.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public String City { get; set; }
    }
}
