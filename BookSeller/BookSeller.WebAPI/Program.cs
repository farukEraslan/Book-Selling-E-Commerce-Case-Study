namespace BookSeller.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // DI Containers
            builder.Services.AddDataAccessServices().AddBusinessServices();

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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
