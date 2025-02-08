using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "User Name")]
        public override string UserName { get; set; }
    }
}
