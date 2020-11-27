using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table ("InfractionTypes")]
    public class InfractionType
    {

        [Key]
        public int InfractionTypeID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Points { get; set; }

    }
}