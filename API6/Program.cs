using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<API6.Models.pract100Context>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("con")));


var app = builder.Build();
app.UseHttpsRedirection();  

app.MapControllers();  


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
