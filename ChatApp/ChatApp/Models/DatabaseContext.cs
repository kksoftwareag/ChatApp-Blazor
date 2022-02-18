using Microsoft.EntityFrameworkCore;

namespace ChatApp.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<ChatMessageModel> ChatMessages { get; set; }
    }
}
