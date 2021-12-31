using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reservation.Application.Contracts.BookCategory;

namespace BookReservation.Pages
{
    public class CreateBookCategoryModel : PageModel
    {
        IBookCategoryApplication bookCategoryApplication;

        public CreateBookCategoryModel(IBookCategoryApplication bookCategoryApplication)
        {
            this.bookCategoryApplication = bookCategoryApplication;
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost(CreateBookCategory command)
        {
            bookCategoryApplication.Create(command);
            return RedirectToPage("./BookCategory");
        }
    }
}
