using Microsoft.AspNetCore.Http;
using TestimonialSlider.Models.DataAnnotaions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace TestimonialSlider.Models
{
    [Table("User_Profiles")]
    public class UserProfile
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Registered User ID")]
        public int RegisteredUserId { get; set; }

        [Column("Country ID")]
        public int CountryId { get; set; }

        [Column("Time_Stamp")]
        [NotMapped]
        public Byte[]? TimeStamp { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [Range(1, 3, ErrorMessage = "Please Seclect The Gender")]
        [Column("Gender")]
        public EnumGender Gender { get; set; }

        [Column("User Job Title")]
        [Required(AllowEmptyStrings = true)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string UserJobTitle { get; set; }

        [Column("Profile Photo")]
        public Byte[] ProfilePhoto { get; set; }

        [Column("Registration Date")]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        //[MaxFileSize(50 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".gif", ".svg" })]
        public IFormFile PhotoFile { get; set; }

        public virtual ICollection<UserTestimonial> UserTestimonials { get; set; }

        public virtual Country Country { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }
    }

    public enum EnumGender
    {
        [Display(Name = "Not Selected")]
        NotSelected = 0,
        Male,
        Female,
        Other
    }
}
