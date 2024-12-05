using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class NewXlatorViewModel
    {
        public IEnumerable<MembershipType>? MembershipTypes { get; set; }
        public Xlator? Xlator { get; set; }
    }
}
