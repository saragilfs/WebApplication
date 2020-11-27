using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table ("Vehicles")]
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required]
        [MaxLength (10)]
        [Index ("LicensePlate", IsUnique = true)]
        public string LicensePlate { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }
    }
}