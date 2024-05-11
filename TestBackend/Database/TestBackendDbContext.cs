using Microsoft.EntityFrameworkCore;
using TestBackend.Domain.Entities;

namespace TestBackend.Database
{
    public class TestBackendDbContext : DbContext
    {
        public TestBackendDbContext(DbContextOptions<TestBackendDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>(); // <--->
    };
};