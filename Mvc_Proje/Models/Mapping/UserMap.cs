using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Mvc_Proje.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.KullaniciAdi)
                .HasMaxLength(100);

            this.Property(t => t.Ad_Soyad)
                .HasMaxLength(30);

            this.Property(t => t.Sifre)
                .HasMaxLength(20);

            this.Property(t => t.Mail)
                .HasMaxLength(100);

            this.Property(t => t.Dogum)
                .HasMaxLength(50);

            this.Property(t => t.Rol)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.KullaniciAdi).HasColumnName("KullaniciAdi");
            this.Property(t => t.Ad_Soyad).HasColumnName("Ad_Soyad");
            this.Property(t => t.Sifre).HasColumnName("Sifre");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Dogum).HasColumnName("Dogum");
            this.Property(t => t.Rol).HasColumnName("Rol");
        }
    }
}
