using Microsoft.EntityFrameworkCore;
using MyFirstWebAPI.Modal;

namespace MyFirstWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<StudentEntity> StudentRegister { get; set; }


    }
}
