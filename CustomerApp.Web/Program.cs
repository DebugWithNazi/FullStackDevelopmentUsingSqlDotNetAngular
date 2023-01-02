using CustomerApp.Repository.CustomerRepository;
using CustomerApp.Repository.Entities;
using CustomerApp.Service.CustomerService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
var service = builder.Services;
service.AddDbContext<CustomerDbContext>(options => options.UseSqlServer("name=ConnectionStrings:CusomterConnection"));
service.AddScoped<ICustomerRepository, CustomerRepository>();
service.AddScoped<ICustomerService, CustomerService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
