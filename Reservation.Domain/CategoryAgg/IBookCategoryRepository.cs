using Reservation.Application.Contracts.BookCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Domain.CategoryAgg
{
    public interface IBookCategoryRepository
    {
        void Create(BookCategory bookCategory);
        BookCategory GetById(int id);
        void SaveChanges();
        EditBookCategory GetDetails(int id);
        List<BookCategoryViewModel> Search(string name);

        bool Exists (string name);
        List<BookCategoryViewModel> GetAll();
    }
}
