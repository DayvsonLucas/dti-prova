using DTI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DTI.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
