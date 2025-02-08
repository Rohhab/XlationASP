using System.ComponentModel.DataAnnotations;
using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class XlatorFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } = null!;

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please make sure to enter your name")]
        [StringLength(255)]
        public string? Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsLetter { get; set; }

        [MembershipTypeCustomValidator]
        [Required(ErrorMessage = "Please make sure to select membership type")]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [BirthdateCustomValidator]
        public DateTime? Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public XlatorFormViewModel()
        {
            Id = 0;
        }

        public XlatorFormViewModel(Xlator xlator)
        {
            Id = xlator.Id;
            Name = xlator.Name;
            Email = xlator.Email;
            IsSubscribedToNewsLetter = xlator.IsSubscribedToNewsLetter;
            MembershipTypeId = xlator.MembershipTypeId;
            Birthdate = xlator.Birthdate;
        }
    }
}
