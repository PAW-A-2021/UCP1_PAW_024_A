using System;
using System.Collections.Generic;

#nullable disable

namespace MarketProject.Models
{
    public partial class User
    {
        public User()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdUser { get; set; }
        public string NamaUser { get; set; }
        public string NomerTelpon { get; set; }
        public string AlamatUser { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
