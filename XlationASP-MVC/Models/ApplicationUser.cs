using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "User Name")]
        public override string? UserName { get; set; }

        public MembershipType? MembershipType { get; set; }

        [MembershipTypeCustomValidator]
        [Required(ErrorMessage = "Please make sure to select membership type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [BirthdateCustomValidator]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
    }
}
