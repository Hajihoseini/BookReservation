using Microsoft.EntityFrameworkCore;
using Reservation.Application;
using Reservation.Application.Contracts.Book;
using Reservation.Application.Contracts.BookCategory;
using Reservation.Domain.BookAgg;
using Reservation.Domain.CategoryAgg;
using Reservation.Infrastructure.EFCore;
using Reservation.Infrastructure.EFCore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IBookCategoryApplication, BookCategoryApplication>();
builder.Services.AddTransient<IBookCategoryRepository, BookCategoryRepository>();
builder.Services.AddTransient<IBookApplication, BookApplication>();
builder.Services.AddTransient<IBookRepository, BookRepository>();



builder.Services.AddDbContext<EFContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("BRConnection")));

builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
