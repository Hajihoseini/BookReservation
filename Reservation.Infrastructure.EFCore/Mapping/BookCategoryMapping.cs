using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.CategoryAgg;

namespace Reservation.Infrastructure.EFCore.Mapping
{
    public class BookCategoryMapping : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("BookCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.HasMany(x => x.Books).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }

}
