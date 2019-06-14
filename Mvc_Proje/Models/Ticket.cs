using System;
using System.Collections.Generic;

namespace Mvc_Proje.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            this.Yorums = new List<Yorum>();
        }

        public int ID { get; set; }
        public int User_ID { get; set; }
        public string Oncelik { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public string ResimYol { get; set; }
        public Nullable<bool> Durum { get; set; }
        public Nullable<bool> OkunduMu { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Yorum> Yorums { get; set; }
    }
}
