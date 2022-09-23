using catalog.Business.Mapping;
using catalog.Business.Services;
using catalog.DataAccess.Data;
using catalog.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<UserService>();
//Authentication ile gelen token nasıl onaylanacak?
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidIssuer = "albaraka.com",
                        ValidAudience = "albaraka.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cok gizli ve onemli bir cumle"))
                    };
                });

builder.Services.AddCors(option =>
{
    option.AddPolicy("allow", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
    /*
     * https://www.albarakaturk.com.tr
     * https://www.albarakaturk.com.tr/hakkimizda
     * 
     * http://www.albarakaturk.com.tr
     * https://account.albarakaturk.com.tr
     * https://www.albarakaturk.com.tr:8081
     * 
     */
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
