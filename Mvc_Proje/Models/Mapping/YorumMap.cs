using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mvc_Proje.Models.Mapping
{
    public class YorumMap : EntityTypeConfiguration<Yorum>
    {
        public YorumMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Yorum");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Ticket_ID).HasColumnName("Ticket_ID");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.Tarih).HasColumnName("Tarih");
            this.Property(t => t.Icerik_Yorum).HasColumnName("Icerik_Yorum");

            // Relationships
            this.HasRequired(t => t.Ticket)
                .WithMany(t => t.Yorums)
                .HasForeignKey(d => d.Ticket_ID);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Yorums)
                .HasForeignKey(d => d.User_ID);

        }
    }
}
