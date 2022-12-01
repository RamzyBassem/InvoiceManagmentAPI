using AirBnb.BL.AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XlabAssignment.BL.Managers.InvoiceManager;
using XlabAssignment.DAL.Data.Context;
using XlabAssignment.DAL.Repository.InvoiceRepo;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Cors Configuration
string allowPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(allowPolicy, p =>
    {
        p.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true);
    });
});
#endregion
#region Context class Configuration
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion
#region Special Repos
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();


#endregion
#region AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(AutoMapperProfiler).Assembly);
#endregion

#region Managers 
builder.Services.AddScoped<IInvoiceManager, InvoiceManager>();


#endregion
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
app.UseCors(allowPolicy);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
