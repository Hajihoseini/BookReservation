namespace Reservation.Application.Contracts.Book
{
    public class BookViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int BookPrice { get; set; }
        public string Category { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
        public string Author { get; set; }
        public bool IsReserved { get; set; }
    }
}
