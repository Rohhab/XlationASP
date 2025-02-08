using Microsoft.AspNetCore.Identity;
using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class UserFormViewModel
    {
        public ApplicationUser User { get; set; } = null!;
        public IList<String> Roles { get; set; } = null!;
    }
}
