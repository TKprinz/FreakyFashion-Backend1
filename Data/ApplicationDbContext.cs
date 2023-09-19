using Microsoft.EntityFrameworkCore;
using ProjektArbeteFreakyFashion.Domain; 

namespace ProjektArbeteFreakyFashion.Data;


// För att använda DbContext behöver vi installera paket
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
class ApplicationDbContext : DbContext
{
    private string connectionString = "Server=.;Database=ProductManager; Trusted_Connection=True;Encrypt=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Product> Product { get; set; }

}
