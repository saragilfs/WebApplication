using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table ("Drivers")]
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }

        [Required]
        [MaxLength (9)]
        [Index ("IdCard", IsUnique = true)]
        public string IdCard { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Points { get; set; }

    }
}