using Microsoft.EntityFrameworkCore;

namespace EntregaFinal.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

    }
    
}
