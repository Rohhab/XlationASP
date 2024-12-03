namespace XlationASP.Models
{
    public class Book
    {
        public byte Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NoOfPages { get; set; }
    }
}
