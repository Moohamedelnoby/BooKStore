using AutoMapper;
using Book.Store.Presentation;
using Book.Store.Presentation.Core;
using BookStore;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IBookRepo,BookRepo>();
        builder.Services.AddScoped<IAuthorRepo,AuthorRepo>();
        builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
        builder.Services.AddScoped(typeof(IRepositery<>),typeof(Repositery<>));
        builder.Services.AddDbContext<BookStoreContext>(opt =>
        {
            opt.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DBKey"));
        });
       
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
