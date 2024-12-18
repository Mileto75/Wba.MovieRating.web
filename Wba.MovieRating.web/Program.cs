using Microsoft.EntityFrameworkCore;
using Wba.MovieRating.Web.Data;
using Wba.MovieRating.Web.Services;
using Wba.MovieRating.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add database service
builder.Services.AddDbContext<MovieDbContext>(
    options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("MovieDb"))
    );
builder.Services.AddSession();
//add custom services
builder.Services.AddScoped<IFormBuilderService, FormBuilderService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddControllersWithViews();

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
app.UseSession();
app.UseAuthorization();
//app.MapControllerRoute(
//     name: "AdminArea",
//     pattern: "Admin/{controller=Courses}/{action=Index}/{id?}"
//     defaults: new {Area = "Admin",Controller = "Courses", Action = "Index" }
//     );
app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
