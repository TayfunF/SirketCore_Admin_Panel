using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SirketCore.Models
{
    public class Birim
    {
        public int BirimID { get; set; }
        public string BirimAd { get; set; }

        public IList<Personel> Personels { get; set; }
    }
}
