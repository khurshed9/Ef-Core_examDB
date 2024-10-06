using examdb.DataContext;
using examdb.DelayMiddleware;
using examEfCore.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddService();

builder.Services.AddDbContext<ApplicationDBContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseMiddleware<CustomMiddleware>();
}


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
