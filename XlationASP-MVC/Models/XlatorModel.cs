using System.ComponentModel.DataAnnotations;

namespace XlationASP.Models
{
    public class Xlator
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}
