using Microsoft.EntityFrameworkCore;
using UserAccount.GRPC.Entities;

namespace UserAccount.GRPC.Data
{
    public class UserAccountContext : DbContext
    {
        public UserAccountContext(DbContextOptions<UserAccountContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

    }
}
