using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reservation.Application.Contracts.Book;
using Reservation.Application.Contracts.BookCategory;

namespace BookReservation.Pages.Book
{
    public class CreateBookModel : PageModel
    {
        private readonly IBookApplication bookApplication;
        private readonly IBookCategoryApplication bookCategoryApplication;
        public SelectList BookCategories;


        public CreateBookModel(IBookApplication bookApplication, IBookCategoryApplication bookCategoryApplication)
        {
            this.bookApplication = bookApplication;
            this.bookCategoryApplication = bookCategoryApplication;
        }

        public void OnGet()
        {
            BookCategories = new SelectList(bookCategoryApplication.GetAll(), "Id", "Name");
        }

        public RedirectToPageResult OnPost(CreateBook command)
        {
            bookApplication.Create(command);
            return RedirectToPage("./AllBooks");
        }
    }
}
