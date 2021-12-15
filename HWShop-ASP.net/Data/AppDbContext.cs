using Microsoft.EntityFrameworkCore;

namespace HWShop_ASP.net.Data;

public class AppDbContext: DbContext
{
    public DbSet<HW2OnlineShop.Product> ProductDB => Set<HW2OnlineShop.Product>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

}