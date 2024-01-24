namespace BookSeller.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();

            builder.Services.AddScoped<ICartSessionHelper, CartSessionHelper>();

            // DI Containers
            builder.Services.AddDataAccessServices().AddBusinessServices();

            // Serilog Logger
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console()
                .WriteTo.File("LogFiles/BookSellerLog.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollingInterval: RollingInterval.Day)
                .WriteTo.MSSqlServer("Server = ISTN36002\\SQLEXPRESS; Database = BookSeller; uid = sa; pwd = 123; Trusted_Connection = True; TrustServerCertificate = True;",
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",
                        AutoCreateSqlTable = true
                    },
                    restrictedToMinimumLevel: LogEventLevel.Information).CreateLogger();

            builder.Host.UseSerilog();

            // Exception Handler
            //builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            //builder.Services.AddProblemDetails();

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

            // Fluent Validation
            builder.Services.AddFluentValidators();

            // CORS policy için frontend ekibinin host numaralarýnýn ekleneceði yer
            var myOrigins = "_myOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myOrigins,
                    policy =>
                    {
                        policy.WithOrigins("*")
                        .WithMethods("GET", "POST", "PUT", "HEAD", "DELETE", "CONNECT", "OPTIONS", "PATCH", "SEARCH")
                        .AllowAnyHeader();
                    });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // CORS policy aktif edildiði yer
            app.UseCors(myOrigins);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSession();

            // Exception Handler
            //app.UseExceptionHandler();
            app.MapControllers();

            app.Run();
        }
    }
}
