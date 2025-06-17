using Microsoft.EntityFrameworkCore;
using MyApiProjectTest.Data;
using MyAPIProjectTest.Mapper;
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
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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

