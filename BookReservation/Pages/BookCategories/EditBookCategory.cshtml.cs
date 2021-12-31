using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reservation.Application.Contracts.BookCategory;

namespace BookReservation.Pages
{
    public class EditBookCategoryModel : PageModel
    {
        public EditBookCategory Command;
        private readonly IBookCategoryApplication bookCategoryApplication;

        public EditBookCategoryModel(IBookCategoryApplication bookCategoryApplication)
        {
            this.bookCategoryApplication = bookCategoryApplication;
        }

        public void OnGet(int id)
        {
            Command = bookCategoryApplication.GetDetail(id);    
        }
    }
}
