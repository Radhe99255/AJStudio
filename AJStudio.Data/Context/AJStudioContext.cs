using AJStudio.Data.DBTables;
using Microsoft.EntityFrameworkCore;

namespace AJStudio.Data.Context
{
    public class AJStudioContext : DbContext
    {
        public AJStudioContext(DbContextOptions<AJStudioContext> options) : base(options)
        {

        }

        public virtual DbSet<ContactUsDBTable> ContactUsTable { get; set; }
        public virtual DbSet<PlaneVarietyDBTable> PlaneVarietyTable { get; set; }
        public virtual DbSet<SuggestedDBTable> SuggestedTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                // Connection string is into appsetting.json file
                //optionsBuilder.UseSqlServer("Server=DESKTOP-I3K5V6L;Database=AJStudioDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
