using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_20190140005_A.Models
{
    public partial class Casual
    {
        public int IdSepatu { get; set; }
        public int? StockSepatu { get; set; }
        public string NamaSepatu { get; set; }
        public string HargaSepatu { get; set; }
        public string JenisSepatu { get; set; }
        public string UkuranSepatu { get; set; }
        public string BrandSepatu { get; set; }

        public virtual Admin IdSepatuNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
