using XlationASP.Models;

namespace XlationASP.ViewModels
{
    public class XlatorFormViewModel
    {
        public IEnumerable<MembershipType>? MembershipTypes { get; set; }
        public Xlator? Xlator { get; set; }
    }
}
