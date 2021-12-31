using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reservation.Application.Contracts.BookCategory;

namespace BookReservation.Pages
{
    public class BookCategoryModel : PageModel
    {
        public List<BookCategoryViewModel> BookCategories;
        private readonly IBookCategoryApplication bookCategoryApplication;

        public BookCategoryModel(IBookCategoryApplication bookCategoryApplication)
        {
            this.bookCategoryApplication = bookCategoryApplication;
        }

        public void OnGet(string name)
        {
            BookCategories = bookCategoryApplication.Search(name);
        }

    }
}
