using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table ("UsualDrivers")]
    public class UsualDriver
    {
        [Key]
        public int UsualDriverID { get; set; }

        [Required]
        public int DriverID { get; set; }

        [Required]
        public int VehicleID { get; set; }

        public virtual Driver Driver { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
