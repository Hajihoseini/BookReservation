using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Contracts.Book
{
    public interface IBookApplication
    {
        void Create(CreateBook command);
        void Edit(EditBook command);
        void Remove(int id);
        void Restore(int id);
        void Reserved(int id);
        void UnReserved(int id);
        EditBook GetDetails(int id);
        List<BookViewModel> Search(BookSearchModel searchModel);
    }
}
