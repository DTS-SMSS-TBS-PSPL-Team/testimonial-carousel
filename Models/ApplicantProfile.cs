using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SMSS.Models.DataAnnotaions;
using System.Diagnostics.Metrics;

namespace TS.Models
{
    [Table("Applicant_Profiles")]
    public class ApplicantProfile
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Registered_User_ID")]
        public int RegisteredUserId { get; set; }

        [Column("Country_ID")]
        public int? CountryId { get; set; }

        [Column("Time_Stamp")]
        [NotMapped]
        public Byte[] TimeStamp { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [Range(1, 3, ErrorMessage = "Please Seclect The Gender")]
        [Column("Gender")]
        public EnumGender Gender { get; set; }

        [Column("LinkedIn_URL")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string? LinkedIn { get; set; }


        [Column("GitHub_URL")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string? GitHub { get; set; }

        [Column("Profile_URL")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string? ProfileUrl { get; set; }

        [Column("Profile_Is_Public")]
        public bool ProfileIsPublic { get; set; }

        [Column("Job_Profession")]
        [Required(AllowEmptyStrings = true)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string? JobProfession { get; set; }

        [Column("Profile_Img")]
        public Byte[]? ProfileImg { get; set; }

        [Column("RegistrationDate")]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [MaxFileSize(50 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".gif", ".svg" })]
        public IFormFile? ImageFile { get; set; }

        public virtual ICollection<ApplicantTestimonial>? ApplicantTestimonials { get; set; }

        public virtual Country? Country { get; set; }

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
