using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mvc_Proje.Models.Mapping
{
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Oncelik)
                .HasMaxLength(50);

            this.Property(t => t.Konu)
                .HasMaxLength(150);

            this.Property(t => t.ResimYol)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Ticket");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.User_ID).HasColumnName("User_ID");
            this.Property(t => t.Oncelik).HasColumnName("Oncelik");
            this.Property(t => t.Konu).HasColumnName("Konu");
            this.Property(t => t.Icerik).HasColumnName("Icerik");
            this.Property(t => t.ResimYol).HasColumnName("ResimYol");
            this.Property(t => t.Durum).HasColumnName("Durum");
            this.Property(t => t.OkunduMu).HasColumnName("OkunduMu");
            this.Property(t => t.Tarih).HasColumnName("Tarih");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Tickets)
                .HasForeignKey(d => d.User_ID);

        }
    }
}
