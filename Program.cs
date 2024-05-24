using BarCLoudTaskBackEnd.BackGroundServices;
using BarCLoudTaskBackEnd.DataAccess;
using BarCLoudTaskBackEnd.Repositories;
using BarCLoudTaskBackEnd.Services;
using BarCLoudTaskBackEnd.Services.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 Action<DbContextOptionsBuilder> configureDbContext = (o => o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
 builder.Services.AddDbContext<DataBaseContext>(configureDbContext);
builder.Services.AddSingleton<DataBaseContextFactory>(new DataBaseContextFactory(configureDbContext));
Action<HttpClient> configureClientHeader = (client) => { 
    client.BaseAddress = new Uri("https://api.polygon.io/");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration.GetSection("PolygonToken").Value);
    };
builder.Services.AddHttpClient("Polygon", configureClientHeader);
builder.Services.AddScoped<IBarCloudRepository, BarCloudRepository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddSingleton<IPolygonService, PolygonService>();
builder.Services.AddSingleton<IHostedService, AvailableStocksService>();
builder.Services.AddSingleton<IHostedService, StockPriceService>();


var db = builder.Services.BuildServiceProvider().GetRequiredService<DataBaseContext>();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();

                      });
});
//db.Database.EnsureCreated();
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
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
