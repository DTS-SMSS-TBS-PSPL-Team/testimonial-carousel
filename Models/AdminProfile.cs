using Microsoft.AspNetCore.Http;
using TestimonialSlider.Models.DataAnnotaions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TestimonialSlider.Models
{
    [Table("Admin_Profiles")]
    public class AdminProfile
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Registered_User_ID")]
        public int RegisteredUserId { get; set; }

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
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} Length Must Be between {2} and {1} character")]
        public string UserTypeName { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }
    }
}
