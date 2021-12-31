using Reservation.Application.Contracts.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Domain.BookAgg
{
    public interface IBookRepository
    {
        void Create(Book book);
        Book GetById(long id);
        EditBook GetDetail(long id);
        void SaveChanges();
        bool Exists(string name,int categoryId);
        List<BookViewModel> Search(BookSearchModel searchModel);    
    }
}
