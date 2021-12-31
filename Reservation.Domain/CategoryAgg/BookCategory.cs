using Reservation.Domain.BookAgg;

namespace Reservation.Domain.CategoryAgg
{
    public class BookCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public DateTime CreationDate { get; set; }
        public BookCategory(string name)
        {
            Name = name;
            CreationDate = DateTime.Now;
            Books = new List<Book>();
        }

        public void Edit(string name)
        {
            Name=name;
        }
    }
}