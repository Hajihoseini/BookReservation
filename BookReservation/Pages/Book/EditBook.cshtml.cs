using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Reservation.Application;
using Reservation.Application.Contracts.Book;
using Reservation.Application.Contracts.BookCategory;

namespace BookReservation.Pages.Book
{
    public class EditBookModel : PageModel
    {
        public EditBook Command;
        public SelectList BookCategories;
        private readonly IBookApplication bookApplication;
        private readonly IBookCategoryApplication bookCategoryApplication;

        public EditBookModel(IBookApplication bookApplication, IBookCategoryApplication bookCategoryApplication)
        {
            this.bookApplication = bookApplication;
            this.bookCategoryApplication = bookCategoryApplication;
        }

        public void OnGet(int id)
        {
            BookCategories = new SelectList(bookCategoryApplication.GetAll(), "Id", "Name");
            Command = bookApplication.GetDetails(id);
        }

        public RedirectToPageResult OnPost(EditBook command)
        {
            bookApplication.Edit(command);
            return RedirectToPage("./AllBooks");
        }
    }
}
