using System.ComponentModel.DataAnnotations;
using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class UserFormViewModel
    {
        //public IEnumerable<MembershipType> MembershipTypes { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;
        public IList<String> Roles { get; set; } = null!;

        /* public string Id { get; set; }

        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [MembershipTypeCustomValidator]
        [Required(ErrorMessage = "Please make sure to select membership type")]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [BirthdateCustomValidator]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public UserFormViewModel(ApplicationUser applicationUser)
        {
            Id = applicationUser.Id;
            UserName = applicationUser.UserName;
            Birthdate = applicationUser.Birthdate;
            MembershipTypeId = applicationUser.MembershipTypeId;
            IsSubscribedToNewsLetter = applicationUser.IsSubscribedToNewsLetter;
        } */
    }
}
