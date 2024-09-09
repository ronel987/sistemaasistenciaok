using Microsoft.EntityFrameworkCore;
using Sasistencia80.Models;
//Agregada
var MyAllowSpecificationOrigins = "Permisos";
var builder = WebApplication.CreateBuilder(args);
//Agregada
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificationOrigins,
                        policy =>
                        {
                            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                        });
});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BdasistenciaContext>(option =>
  option.UseSqlServer(builder.Configuration.GetConnectionString("TiendaVirtualDBConn")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
   // app.UseSwagger();
   app.UseSwaggerUI();
}
app.UseHttpsRedirection();
//Agregada
app.UseCors(MyAllowSpecificationOrigins);
app.UseAuthorization();

app.MapControllers();
//app.Use((context, next) =>
//{
 //   context.Response.Headers["Access-Control-Allow-Origin"] = "*";
//});
app.Run();
