using Microsoft.EntityFrameworkCore;
using Bbsm_Garage_Son.Entitiy;
using Bbsm_Garage_Son.Interfaces;
using Bbsm_Garage_Son.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    // builder.Services.AddControllers();
    builder.Services.AddControllersWithViews();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    builder.Services.AddAuthentication(options =>
    {
        // options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.AccessDeniedPath = new PathString("/Login21321");
        options.LoginPath = new PathString("/22asd");
    }).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "IssuerInformation",
        ValidAudience = "AudienceInformation",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTAuthenticationHIGHsecuredPasswordVVVp1OH7Xzyr"))
    };
});

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

    builder.Services.AddScoped<KartService, KartService>();
    builder.Services.AddScoped<KartService>();
    builder.Services.AddScoped<StokService, StokService>();
    builder.Services.AddScoped<StokService>();
    
    builder.Services.AddScoped<CardTwoState, CardTwoState>();
    builder.Services.AddScoped<CardTwoState>();
    builder.Services.AddScoped<UserService,UserService>();
    builder.Services.AddScoped<UserService>();

    // Yetkilendirme politikaları tanımlanır.
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireStandartRole", policy =>
        {
            policy.AuthenticationSchemes.Add(CookieAuthenticationDefaults.AuthenticationScheme);
            policy.RequireRole("Standart");
        });
    });

    
    builder.Services.AddTransient<IAuthService, AuthService>();
    builder.Services.AddTransient<ITokenService, TokenService>();

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                // Redirect to login page
                context.Response.Redirect("/Login");
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied = context =>
            {
                context.Response.Redirect("/Error");
                return Task.CompletedTask;
            }
        };
    });

    builder.Services.AddSwaggerGen();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
