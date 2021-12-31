using Microsoft.EntityFrameworkCore;
using Reservation.Application.Contracts.Book;
using Reservation.Domain.BookAgg;

namespace Reservation.Infrastructure.EFCore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly EFContext _context;

        public BookRepository(EFContext context)
        {
            _context = context;
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
        }

        public bool Exists(string name, int categoryId)
        {
            return _context.Books.Any(x=>x.Name == name && x.CategoryId == categoryId);
        }

        public Book GetById(long id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public EditBook GetDetail(long id)
        {
            return _context.Books.Select(x => new EditBook
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId = x.CategoryId,
                BookPrice = x.Price,
                Author = x.Author,  
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<BookViewModel> Search(BookSearchModel searchModel)
        {
            var query = _context.Books
                .Include(x => x.Category)
                .Select(x => new BookViewModel
                {
                    Id=x.Id,
                    Name=x.Name,
                    BookPrice=x.Price,
                    Author=x.Author,
                    IsReserved=x.IsReserved,
                    IsRemoved=x.IsRemoved,
                    CreationDate=x.CreationDate.ToString(),
                    Category=x.Category.Name
                }).Where(x=>x.IsRemoved==false);

            if(searchModel.IsRemoved == true)
                query = query.Where(x => x.IsRemoved == true);

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name.Contains(searchModel.Name));

            return query
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .ToList();
        }
    }
}
