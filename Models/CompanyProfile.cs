using SMSS.Models.DataAnnotaions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TS.Models
{
    [Table("Company_Profiles")]
    public class CompanyProfile
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("Registered_User_ID")]
        public int RegisteredUserId { get; set; }


        [Column("Company_Website")]
        [Url]
        [Required]
        public string CompanyWebsite { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter the valid phone number.")]
        [Display(Name = "Phone Number")]
        [Column("Contact_Phone")]
        public string ContactPhone { get; set; }

        [Required]
        [Column("Contact_Name")]
        [Display(Name = "Contact Name")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string ContactName { get; set; }


        [Column("Email1")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email1 { get; set; }


        [Column("Email2")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]

        public string Email2 { get; set; }



        [Column("Description")]
        [StringLength(2000, MinimumLength = 3, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string Description { get; set; }

        [Column("Company_Logo")]
        public Byte[] CompanyLogo { get; set; }

        [Column("LinkedInURL")]
        public string LinkedIn { get; set; }

        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }

        [Column("Is_Approved")]
        [DefaultValue("false")]
        public bool IsApproved { get; set; }

        [Column("Time_Stamp")]
        [NotMapped]
        public Byte[] TimeStamp { get; set; }

        [Column("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [MaxFileSize(50 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".gif", ".svg" })]
        public IFormFile LogoFile { get; set; }

        [NotMapped]
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string OrganizationName { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }
        //public virtual ICollection<CompanyJob> CompanyJobs { get; set; }
        //public virtual ICollection<CompanyLocation> CompanyLocations { get; set; }

    }
}
