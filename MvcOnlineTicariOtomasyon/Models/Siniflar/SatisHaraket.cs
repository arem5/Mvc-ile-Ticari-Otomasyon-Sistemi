using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHaraket
    {
        [Key]
        public int SatisID { get; set; }

        //Ürün  ilişkisel olacaklar
        //Cari
        //Personel
        public DateTime SatisTarihi { get; set; }
        public int SatisAdet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        //Her biri için satıştan değer alacağı bir ilişki gerek, her classa satis haraket ekleriz.
        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }


        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }
    }
}