using Reservation.Domain.CategoryAgg;

namespace Reservation.Domain.BookAgg
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsReserved { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public BookCategory Category { get; set; }
        public DateTime CreationDate { get; set; }

        public Book(string name, int price, string author,int categoryId)
        {
            Name = name;
            Price = price;
            Author = author;
            CategoryId = categoryId;
            CreationDate = DateTime.Now;
        }

        public void Edit(string name, int price, string author, int categoryId)
        {
            Name = name;
            Price = price;
            Author = author;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved= false;
        }

        public void Reserved()
        {
            IsReserved = true;
        }

        public void UnReserved()
        {
            IsReserved= false;
        }
    }
}
