namespace XlationASP.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public short DiscountRate { get; set; }
        public string Name { get; set; }
    }
}
