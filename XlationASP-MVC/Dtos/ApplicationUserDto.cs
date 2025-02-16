using System.ComponentModel.DataAnnotations;
using XlationASP.Models;

namespace XlationASP.Dtos
{
    public class ApplicationUserDto
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public MembershipTypeDto MembershipType { get; set; } = null!;

        public byte MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public List<string> Roles { get; set; } = null!;
    }
}
