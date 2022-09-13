using Microsoft.EntityFrameworkCore;
using UserApi.Model;

namespace UserApi.Context
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
