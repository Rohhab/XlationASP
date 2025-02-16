using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class Xlator
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please make sure to enter your name")]
        [StringLength(255)]
        public string Name { get; set; } = null!;

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType? MembershipType { get; set; }

        [MembershipTypeCustomValidator]
        [Required(ErrorMessage = "Please make sure to select membership type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [BirthdateCustomValidator]
        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; } = null!;
    }
}
