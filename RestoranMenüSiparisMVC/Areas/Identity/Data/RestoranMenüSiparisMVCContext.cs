using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestoranMenüSiparisMVC.Areas.Identity.Data;
using RestoranMenüSiparisMVC.Models;

namespace RestoranMenüSiparisMVC.Data;

public class RestoranMenüSiparisMVCContext : IdentityDbContext<RestoranMenüSiparisMVCUser>
{
    public DbSet<ProductViewModel> Products { get; set; }
    public DbSet<OrdersDetailsViewModel> Orders { get; set; }
    public RestoranMenüSiparisMVCContext(DbContextOptions<RestoranMenüSiparisMVCContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
