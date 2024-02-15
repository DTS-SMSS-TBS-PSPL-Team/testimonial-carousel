
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TS.Models
{
    public class RegisteredUser : IdentityUser<int>
    {
        [PersonalData]
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only")]
        public string FirstName { get; set; }

        [PersonalData]
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only")]
        public string LastName { get; set; }

        [PersonalData]
        [Required]
        [StringLength(13, MinimumLength = 10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter the valid phone number.")]
        [Display(Name = "Phone Number")]
        public string UserPhone { get; set; }

        public string? UserTypeName { get; set; }
        public byte UserFlag { get; set; }

        public virtual ApplicantProfile ApplicantProfile { get; set; }
        public virtual AdminProfile AdminProfile { get; set; }
    }

}
