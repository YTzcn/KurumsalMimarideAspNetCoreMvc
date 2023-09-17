using Abc.Northwind.MvcWebUI.Entities;
using Abc.Northwind.MvcWebUI.Middlewares;
using Abc.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mvc.Northwind.Business.Abstract;
using Mvc.Northwind.Business.Concrete;
using Mvc.Northwind.DataAccess.Abstract;
using Mvc.Northwind.DataAccess.Concrete.EntityFramework;

namespace Abc.Northwind.MvcWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMvc();

            builder.Services.AddSession();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDal, EfProductDal>();

            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

            builder.Services.AddSingleton<ICartService, CartManager>();
            builder.Services.AddSingleton<ICartSessionService, CartSessionService>();

            builder.Services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Northwind;Integrated Security=true;TrustServerCertificate=True;"));
            builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseNodeModules(builder.Environment.ContentRootPath);

            app.UseAuthentication();
            app.UseSession();

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}