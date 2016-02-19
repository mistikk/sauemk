using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sauemk.web.Models
{
    public class EtkinlikModel
    {
        public string EtkinlikAdi { get; set; }
        public DateTime EtkinlikTarihi { get; set; }
        public DateTime AcilisTarihi { get; set; }
        public DateTime KapanisTarihi { get; set; }
        public string Aciklama { get; set; }
    }
}