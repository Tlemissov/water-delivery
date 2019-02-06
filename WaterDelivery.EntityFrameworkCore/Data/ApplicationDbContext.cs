using Microsoft.EntityFrameworkCore;
using WaterDelivery.Core.Users;

namespace WaterDelivery.EntityFrameworkCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
