using Microsoft.EntityFrameworkCore;
using WaterDelivery.Core.Users;
using WaterDelivery.Core.Orders;

namespace WaterDelivery.EntityFrameworkCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
