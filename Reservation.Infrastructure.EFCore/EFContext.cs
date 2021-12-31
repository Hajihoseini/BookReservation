using Microsoft.EntityFrameworkCore;
using Reservation.Domain.BookAgg;
using Reservation.Domain.CategoryAgg;
using Reservation.Infrastructure.EFCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Infrastructure.EFCore
{
    public class EFContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(BookMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
