using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table ("Infractions")]
    public class Infraction
    {
        [Key]
        public int InfractionID { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int DriverID { get; set; }

        [Required]
        public int VehicleID { get; set; }

        [Required]
        public int InfractionTypeID { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual InfractionType InfractionType { get; set; }

    }
}
