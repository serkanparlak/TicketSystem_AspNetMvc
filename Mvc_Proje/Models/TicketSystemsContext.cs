using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mvc_Proje.Models.Mapping;

namespace Mvc_Proje.Models
{
    public partial class TicketSystemsContext : DbContext
    {
        static TicketSystemsContext()
        {
            Database.SetInitializer<TicketSystemsContext>(null);
        }

        public TicketSystemsContext()
            : base("Name=TicketSystemsContext")
        {
        }

        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TicketMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new YorumMap());
        }
    }
}
