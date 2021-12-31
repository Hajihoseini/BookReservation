using Reservation.Application.Contracts.BookCategory;
using Reservation.Domain.CategoryAgg;

namespace Reservation.Application
{
    public class BookCategoryApplication : IBookCategoryApplication
    {
        private readonly IBookCategoryRepository bookCategoryRepository;

        public BookCategoryApplication(IBookCategoryRepository bookCategoryRepository)
        {
            this.bookCategoryRepository = bookCategoryRepository;
        }

        public void Create(CreateBookCategory command)
        {
            if (bookCategoryRepository.Exists(command.Name))
                return;

            var bookCategory = new BookCategory(command.Name);
            bookCategoryRepository.Create(bookCategory);
            bookCategoryRepository.SaveChanges();
        }

        public void Edit(EditBookCategory command)
        {
            var bookCategory = bookCategoryRepository.GetById(command.Id);
            if (bookCategory == null)
                return;

            bookCategory.Edit(command.Name);
            bookCategoryRepository.SaveChanges();
        }

        public List<BookCategoryViewModel> GetAll()
        {
            return bookCategoryRepository.GetAll();
        }

        public EditBookCategory GetDetail(int id)
        {
           return bookCategoryRepository.GetDetails(id);
        }

        public List<BookCategoryViewModel> Search(string name)
        {
            return bookCategoryRepository.Search(name);
        }
    }
}