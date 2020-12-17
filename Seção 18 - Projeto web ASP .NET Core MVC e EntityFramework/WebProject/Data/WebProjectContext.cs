using Microsoft.EntityFrameworkCore;

namespace WebProject.Data
{
    public class WebProjectContext:DbContext
    {
        public WebProjectContext(DbContextOptions<WebProjectContext> options)
            : base(options)
        {
        }

        public DbSet<WebProject.Models.Department> Department { get; set; }
        public DbSet<WebProject.Models.Seller> Seller { get; set; }
        public DbSet<WebProject.Models.SalesRecord> SalesRecord { get; set; }
    }
}
