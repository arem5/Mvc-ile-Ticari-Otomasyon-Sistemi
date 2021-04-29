using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName ="VarChar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemesiniz.")]
        public string UrunAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemesiniz.")]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyatı { get; set; }
        public decimal SatisFiyatı { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int Kategoriid { get; set; }
        public virtual Kategori Kategori { get; set; }  //Veri tabanında KAtegoriID ye dönüşür .Virtual yazarak kalıtım aldığımız sınıfların da değerlerine ulaşırız. Urun.Indexde Kategori ismi gelmesi için
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
    }
}