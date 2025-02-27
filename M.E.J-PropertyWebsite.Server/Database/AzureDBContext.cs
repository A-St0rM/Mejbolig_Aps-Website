using M.E.J_PropertyWebsite.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace M.E.J_PropertyWebsite.Server.Database
{
    public class AzureDBContext : DbContext
    {
        public AzureDBContext(DbContextOptions<AzureDBContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
    }
}
