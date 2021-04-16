using database_monitoring.Models;
using Microsoft.EntityFrameworkCore;

namespace database_monitoring.Data {
    public class DatabaseServerContext : DbContext {
        public DatabaseServerContext(DbContextOptions<DatabaseServerContext> opt) : base(opt)
        {
            
        }
        public DbSet<DatabaseServer> DatabaseServers { get; set; }
    }
}