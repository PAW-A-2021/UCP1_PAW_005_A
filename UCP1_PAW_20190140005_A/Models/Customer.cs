using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_20190140005_A.Models
{
    public partial class Customer
    {
        public int IdSepatu { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Casual IdSepatuNavigation { get; set; }
        public virtual Sporty Sporty { get; set; }
    }
}
