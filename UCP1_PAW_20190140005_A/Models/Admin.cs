using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_20190140005_A.Models
{
    public partial class Admin
    {
        public int IdSepatu { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Casual Casual { get; set; }
        public virtual Sporty Sporty { get; set; }
    }
}
