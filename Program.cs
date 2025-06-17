using Microsoft.EntityFrameworkCore;
using MyApiProjectTest.Data;
using MyAPIProjectTest.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NzWalksDbContext>(options => 
options.UseSqlite(builder.Configuration.GetConnectionString("NzWalksConnectionString")));
builder.Services.AddScoped(typeof(IDbRepository), typeof(RegionDBRepository));

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

