using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TestimonialSlider.Models
{
    public class Country
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Country Name")]
        public string Name { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }

        public static implicit operator Country(List<SelectList> c)
        {
            throw new NotImplementedException();
        }
    }
}
