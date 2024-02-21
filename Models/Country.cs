using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TS.Models
{
    public class Country
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<ApplicantProfile> ApplicantProfiles { get; set; }

        public static implicit operator Country(List<SelectListItem> v)
        {
            throw new NotImplementedException();
        }

    }
}
