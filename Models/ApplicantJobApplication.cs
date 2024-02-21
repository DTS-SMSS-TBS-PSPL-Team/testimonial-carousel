using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TS.Models
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplication
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Applicant_Profile_ID")]
        public int? ApplicantProfileId { get; set; }

        [Column("Company_Job_Id")]
        public int? CompanyJobId { get; set; }

        //[Column("Job_Mode_ID")]
        //public int? JobModeId { get; set; }

        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }

        [Column("Resume_Location")]
        public string ResumeLocation { get; set; }

        [Column("CoverLetter_Location")]
        public string CoverLetterLocation { get; set; }

        [Column("Skill_Matrix_Location")]
        public string SkillMatrixLocation { get; set; }

        [Column("Expected_Salary")]
        [Required]
        [DefaultValue(" ")]
        [Display(Name = "Expected Salary")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string ExpectedSalary { get; set; }

        [Column("Delete_Flag")]
        [DefaultValue("false")]
        public bool DeleteFlag { get; set; }

        [Column("Application_Status")]
        public ApplicationStatus ApplicationStatus { get; set; }

        [Column("Time_Stamp")]
        [NotMapped]
        public Byte[] TimeStamp { get; set; }

        public virtual ApplicantProfile ApplicantProfile { get; set; }
        //public virtual CompanyJob CompanyJob { get; set; }

        //public virtual JobMode JobMode { get; set; }




    }


    public enum ApplicationStatus
    {

        [Display(Name = "New")]
        New = 1,
        [Display(Name = "Viewed")]
        Viewed,
        [Display(Name = "Short Listed")]
        ShortListed,
        [Display(Name = "Rejected")]
        Rejected,
    }
}
