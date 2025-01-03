using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestoranMenüSiparisMVC.Areas.Identity.Data;
using RestoranMenüSiparisMVC.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RestoranMenüSiparisMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'RestoranMenüSiparisMVCContextConnection' not found.");

builder.Services.AddDbContext<RestoranMenüSiparisMVCContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<RestoranMenüSiparisMVCUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<RestoranMenüSiparisMVCContext>();


// Add services to the container.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
