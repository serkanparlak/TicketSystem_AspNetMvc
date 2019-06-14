using System;
using System.Collections.Generic;

namespace Mvc_Proje.Models
{
    public partial class User
    {
        public User()
        {
            this.Tickets = new List<Ticket>();
            this.Yorums = new List<Yorum>();
        }

        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Ad_Soyad { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string Dogum { get; set; }
        public string Rol { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
