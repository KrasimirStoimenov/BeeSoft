using BeeSoft.Data;
using BeeSoft.Services.Apiaries;
using BeeSoft.Services.AutoMappingProfile;
using BeeSoft.Services.BeeQueens;
using BeeSoft.Services.Diseases;
using BeeSoft.Services.Expenses;
using BeeSoft.Services.Harvests;
using BeeSoft.Services.Hives;
using BeeSoft.Services.Inspections;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews(options => options
        .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

builder.Services
    .AddDbContext<BeeSoftDbContext>(options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("BeeSoftDb")))
    .AddAutoMapper(options =>
        options.AddProfile<MappingProfile>());

builder.Services.AddScoped<IApiariesService, ApiariesService>();
builder.Services.AddScoped<IHivesService, HivesService>();
builder.Services.AddScoped<IBeeQueensService, BeeQueensService>();
builder.Services.AddScoped<IDiseasesService, DiseasesService>();
builder.Services.AddScoped<IHarvestsService, HarvestsService>();
builder.Services.AddScoped<IInspectionsService, InspectionsService>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
    });

app.Run();
