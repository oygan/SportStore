using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete.Repository
{
    /// <summary>
    /// Entities 
    /// </summary>
    public class EFDbContext : DbContext 
    {
        /// <summary>
        /// Products
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
}
