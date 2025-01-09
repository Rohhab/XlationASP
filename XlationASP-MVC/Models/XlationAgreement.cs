using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class XlationAgreement
    {
        public int Id { get; set; }

        [Required]
        public IList<Xlator> Xlators { get; set; } = null!;

        [Required]
        public IList<Book> Books { get; set; } = null!;

        [Required]
        public DateTime DateOfAgreement { get; set; }

        [Required]
        public TimeSpan AgreementDuration { get; set; }
    }
}