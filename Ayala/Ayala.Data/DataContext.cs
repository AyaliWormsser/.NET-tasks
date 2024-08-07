using Microsoft.EntityFrameworkCore;

namespace Ayala.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Core.Entitie.Task> Tasks { get; set; }

        //server=(localdb)\mssqllocaldb; database=my_db

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=my_db");


            // add-migration createDB
        }
    }
}
