using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryProject.API.Services;
using LibraryProject.Business.Extension;
using LibraryProject.Business.Security.JWT;
using LibraryProject.Business.ValidationRules;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.EntityFramework;
using LibraryProject.DataAccess.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<BookAddValidator>(); //tüm validatorleri ekler
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// 2. Bizim yazdýðýmýz servisi tanýt (Scoped olmasý önemli)
builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddSwaggerGen(c =>
{
    // Kilit ikonunu ekle
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Token'ý þuraya yapýþtýr: 'Bearer eyJhbGciOiJIUz...'"
    });

    // Kilit ikonunu aktifleþtir
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

// 2. Authentication Servisini Ekle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, // Ýmza kontrolü en önemlisi!

            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),

            // Token süresi bittiði an hata ver (Normalde 5 dk tolerans tanýr, onu sýfýrlýyoruz)
            ClockSkew = TimeSpan.Zero
        };
    });
var app = builder.Build();
app.UseMiddleware<LibraryProject.API.Middlewares.GlobalExceptionMiddleware>();  //middleware ekleme

// Configure the HTTP request pipeline.


    app.UseSwagger();
    app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<LibraryContext>();
        // Eðer veritabaný yoksa oluþtur, bekleyen migration varsa uygula.
        context.Database.Migrate();

        // (Ýstersen buraya ilk Admin kullanýcýsýný ekleyen kod da yazýlýr - Seed Data)
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Veritabaný oluþturulurken hata çýktý.");
    }
}
//app.UseHttpsRedirection();
app.UseAuthentication(); // 1. Sen kimsin? (Kimlik Kontrolü)
app.UseAuthorization();  // 2. Yetkin var mý? (Yetki Kontrolü)

app.UseStaticFiles(); // wwwroot klasörünü kullanmak için
app.MapControllers();

app.Run();
