using InsuranceApp.Application.Interfaces;
using InsuranceApp.Application.Managers;
using InsuranceApp.Infrastructure;
using InsuranceApp.Infrastructure.Interfaces;
using InsuranceApp.Infrastructure.Repositories;
using InsuranceApp.Presentation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IInsuranceRepository, InsuranceRepository>();
builder.Services.AddScoped<IInsuredPersonRepository, InsuredPersonRepository>();

builder.Services.AddScoped<IInsuredPersonManager, InsuredPersonManager>();
builder.Services.AddScoped<IInsuranceManager, InsuranceManager>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=InsuredPerson}/{action=Index}/{id?}");

app.Run();
