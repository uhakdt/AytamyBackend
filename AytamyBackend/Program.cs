// DEPENDENCIES
global using AytamyBackend.Data;
global using Microsoft.EntityFrameworkCore;
global using AytamyBackend.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// SERVICES
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AytamyDbConnectionString"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Aytamy API",
        Version = "v0.1",
        Description = "An API to perform operations on Users",
        Contact = new OpenApiContact {
            Name = "Mier Rashid",
            Email = "uhakdt@gmail.com",
            Url = new Uri("https://twitter.com/mierrashid"),
        }
    });
});

// BUILD
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();