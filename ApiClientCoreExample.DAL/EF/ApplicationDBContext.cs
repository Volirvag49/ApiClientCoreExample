using Microsoft.EntityFrameworkCore;
using ApiClientCoreExample.DAL.Entities;

namespace ApiClientCoreExample.DAL.EF
{
    public class ApplicationDBContext :DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
                : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
