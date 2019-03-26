using System.Data.Entity;

namespace Models
{
    public class MixedNotesDbContext : DbContext
    {
        public MixedNotesDbContext()
            : base()
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}