using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace TS.Models
{
    [Table("Applicant_Testimonial")]
    public class ApplicantTestimonial
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Applicant_Profile_ID")]
        public int ApplicantProfileId { get; set; }

        [Column("Testimonial")]
        [Required]
        public string Testimonial { get; set; }

        [Column("Description")]
        [Required]
        public string Description { get; set; }

        [Column("IsApprove")]
        public bool IsApprove { get; set; }
    }
}
