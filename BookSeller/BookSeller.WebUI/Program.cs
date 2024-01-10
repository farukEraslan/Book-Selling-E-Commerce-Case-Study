using BookSeller.Business.MapProfiles;
using BookSeller.DataAccess.Concrete.EntityFramework.Contexts;
using BookSeller.DataAccess.DependencyInjections;
using BookSeller.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BookSeller.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // HttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            // Database Connection String
            builder.Services.AddDbContext<BookSellerDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Automapper
            builder.Services.AddAutoMapper(typeof(EntityMapper));

            // Identity
            builder.Services.AddDefaultIdentity<UserEntity>(options =>
            {

            }).AddRoles<RoleEntity>().AddEntityFrameworkStores<BookSellerDbContext>();

            // Login Cookie Settings
            builder.Services.ConfigureApplicationCookie(config =>
            {
                //Login Path
                config.LoginPath = new PathString("/Home/Login");
                config.AccessDeniedPath = new PathString("/Home/Error");
                config.Cookie.HttpOnly = true;
                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromHours(1);
            });

            // Cookienin süresini ayarlama
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Yetki Kontrolü Tanýtma
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("Admin");
                });

                options.AddPolicy("Customer", policy =>
                {
                    policy.RequireRole("Customer");
                });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
