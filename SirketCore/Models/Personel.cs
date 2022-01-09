using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SirketCore.Models
{
    public class Personel
    {
        public int PersonelID { get; set; }
        public string Ad { get; set; }
        public String Soyad { get; set; }
        public string Sehir { get; set; }
        public int BirimID { get; set; }
        public Birim Birim { get; set; }
    }
}
