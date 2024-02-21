using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TS.Models
{
    public class UserSector
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("User_ID")]
        public int RegisteredUserId { get; set; }

        [Column("Sector_ID")]
        public int SectorId { get; set; }

        public virtual RegisteredUser registeredUser { get; set; }

        //public virtual Sector Sector { get; set; }
    }
}
