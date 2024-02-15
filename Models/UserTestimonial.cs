using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TestimonialSlider.Models
{
    [Table("User Testimonial")]
    public class UserTestimonial
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("User Profile ID")]
        public int UserProfileId { get; set; }

        [Column("Testimonial Content")]
        [Required]
        public string Testimonial { get; set; }

        [Column("IsApprove")]
        public bool IsApprove { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
