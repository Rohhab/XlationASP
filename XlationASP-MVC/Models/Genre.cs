using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;
    }
}
