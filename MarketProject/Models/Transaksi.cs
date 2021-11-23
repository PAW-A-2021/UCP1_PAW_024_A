using System;
using System.Collections.Generic;

#nullable disable

namespace MarketProject.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int IdAdmin { get; set; }
        public int IdUser { get; set; }
        public int IdProduk { get; set; }
        public decimal? TotalTransaksi { get; set; }
        public DateTime? TanggalTransaksi { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Produk IdProdukNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
