using Reservation.Application.Contracts.Book;
using Reservation.Domain.BookAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application
{
    public class BookApplication : IBookApplication
    {
        private readonly IBookRepository bookRepository;

        public BookApplication(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Create(CreateBook command)
        {
            if (bookRepository.Exists(command.Name, command.CategoryId))
                return;

            var book = new Book(command.Name, command.BookPrice, command.Author, command.CategoryId);
            bookRepository.Create(book);
            bookRepository.SaveChanges();
        }

        public void Edit(EditBook command)
        {
            var book = bookRepository.GetById(command.Id);
            if (book == null) return;
            book.Edit(command.Name, command.BookPrice, command.Author, command.CategoryId);
            bookRepository.SaveChanges();
        }

        public EditBook GetDetails(int id)
        {
           return bookRepository.GetDetail(id);
        }

        public void Remove(int id)
        {
            var book = bookRepository.GetById(id);
            if (book == null) return;
            book.Remove();
            bookRepository.SaveChanges();
        }

        public void Reserved(int id)
        {
            var book = bookRepository.GetById(id);
            if (book == null) return;
            book.Reserved();
            bookRepository.SaveChanges();
        }

        public void Restore(int id)
        {
            var book = bookRepository.GetById(id);
            if (book == null) return;
            book.Restore();
            bookRepository.SaveChanges();
        }

        public List<BookViewModel> Search(BookSearchModel searchModel)
        {
            return bookRepository.Search(searchModel);
        }

        public void UnReserved(int id)
        {
            var book = bookRepository.GetById(id);
            if (book == null) return;
            book.UnReserved();
            bookRepository.SaveChanges();
        }
    }
}
