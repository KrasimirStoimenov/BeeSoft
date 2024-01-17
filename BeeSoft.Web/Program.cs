using BeeSoft.Data;
using BeeSoft.Services.Apiary;
using BeeSoft.Services.AutoMappingProfile;

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

builder.Services.AddScoped<IApiaryService, ApiaryService>();

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
