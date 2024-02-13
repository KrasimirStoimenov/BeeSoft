using System.Globalization;

using BeeSoft.Data;
using BeeSoft.Services.Apiaries;
using BeeSoft.Services.AutoMappingProfile;
using BeeSoft.Services.BeeQueens;
using BeeSoft.Services.Diseases;
using BeeSoft.Services.Expenses;
using BeeSoft.Services.Harvests;
using BeeSoft.Services.Hives;
using BeeSoft.Services.Inspections;

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews(options => options
        .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()))
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

builder.Services
    .AddDbContext<BeeSoftDbContext>(options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("BeeSoftDb")))
    .AddAutoMapper(options =>
        options.AddProfile<MappingProfile>());

builder.Services
    .AddLocalization(opt => opt.ResourcesPath = "Resources")
    .Configure<RequestLocalizationOptions>(opt =>
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("bg-BG"),
        };
        opt.DefaultRequestCulture = new RequestCulture(supportedCultures[0]);
        opt.SupportedCultures = supportedCultures;
        opt.SupportedUICultures = supportedCultures;
    });

builder.Services.AddTransient<IApiariesService, ApiariesService>();
builder.Services.AddTransient<IHivesService, HivesService>();
builder.Services.AddTransient<IBeeQueensService, BeeQueensService>();
builder.Services.AddTransient<IDiseasesService, DiseasesService>();
builder.Services.AddTransient<IHarvestsService, HarvestsService>();
builder.Services.AddTransient<IInspectionsService, InspectionsService>();
builder.Services.AddTransient<IExpensesService, ExpensesService>();

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
    .UseRequestLocalization()
    .UseRouting()
    .UseAuthorization()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
    });

app.Run();
