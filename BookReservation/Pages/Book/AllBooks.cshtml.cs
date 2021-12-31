using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reservation.Application.Contracts.Book;

namespace BookReservation.Pages.Book
{
    public class AllBooksModel : PageModel
    {
        public List<BookViewModel> Books;
        private readonly IBookApplication bookApplication;

        public AllBooksModel(IBookApplication bookApplication)
        {
            this.bookApplication = bookApplication;
        }

        public void OnGet(BookSearchModel searchModel)
        {
            Books = bookApplication.Search(searchModel);
        }

        public IActionResult OnGetRemove(int id)
        {
            bookApplication.Remove(id);
            return RedirectToPage("./AllBooks");
        }

        public void Restore(int id)
        {
            bookApplication.Restore(id);    
        }
    }
}
