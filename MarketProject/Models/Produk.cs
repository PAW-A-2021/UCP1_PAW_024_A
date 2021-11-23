using System;
using System.Collections.Generic;

#nullable disable

namespace MarketProject.Models
{
    public partial class Produk
    {
        public Produk()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdProduk { get; set; }
        public string NamaProduk { get; set; }
        public string HargaProduk { get; set; }
        public string JumlahProduk { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
