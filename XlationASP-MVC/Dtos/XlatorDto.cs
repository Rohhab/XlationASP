using System.ComponentModel.DataAnnotations;
using XlationASP.Models;

namespace XlationASP.Dtos
{
    public class XlatorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please make sure to enter your name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [MembershipTypeCustomValidator]
        [Required(ErrorMessage = "Please make sure to select membership type")]
        public byte MembershipTypeId { get; set; }

        [BirthdateCustomValidator]
        public DateTime? Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
