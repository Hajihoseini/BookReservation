using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Contracts.BookCategory
{
    public interface IBookCategoryApplication
    {
        void Create(CreateBookCategory command);
        void Edit(EditBookCategory command);
        EditBookCategory GetDetail(int id);
        List<BookCategoryViewModel> Search(string name);
        List<BookCategoryViewModel> GetAll();
    }
}
