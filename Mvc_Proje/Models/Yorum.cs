using System;
using System.Collections.Generic;

namespace Mvc_Proje.Models
{
    public partial class Yorum
    {
        public int ID { get; set; }
        public int Ticket_ID { get; set; }
        public int User_ID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Icerik_Yorum { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
