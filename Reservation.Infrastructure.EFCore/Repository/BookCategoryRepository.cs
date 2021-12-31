using Reservation.Application.Contracts.BookCategory;
using Reservation.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Infrastructure.EFCore.Repository
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly EFContext eFContext;

        public BookCategoryRepository(EFContext eFContext)
        {
            this.eFContext = eFContext;
        }

        public void Create(BookCategory bookCategory)
        {
            eFContext.BookCategories.Add(bookCategory);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return eFContext.BookCategories.Any(x=>x.Name == name);
        }

        public List<BookCategoryViewModel> GetAll()
        {
            return eFContext.BookCategories.Select(x => new BookCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public BookCategory GetById(int id)
        {
           return eFContext.BookCategories.FirstOrDefault(x=>x.Id == id);
        }

        public EditBookCategory GetDetails(int id)
        {
            var detail=  eFContext.BookCategories.Select(x => new EditBookCategory {
                Id = x.Id,
                Name=x.Name,
            }).FirstOrDefault(x=>x.Id == id);

            return detail;
        }

        public void SaveChanges()
        {
            eFContext.SaveChanges();
        }

        public List<BookCategoryViewModel> Search(string name)
        {
            var query = eFContext.BookCategories
                .Select(x => new BookCategoryViewModel
                {
                    Id = x.Id,
                    Name=x.Name,
                    CreationDate = x.CreationDate.ToString()
                });

            if(!string.IsNullOrEmpty(name))
                query = query.Where(x=>x.Name.Contains(name));

            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
