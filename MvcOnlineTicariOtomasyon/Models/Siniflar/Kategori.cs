using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {   //One-to-many ürün ile ilişki
        [Key]
        public int KategoriID { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "VarChar")]
        [StringLength(30,ErrorMessage ="Bu alan en fazla 30 karakter olabilir.")]
        [Required(ErrorMessage ="Bu alanı girmek zorundasınız.")]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; } //İlişkilendirmek için C# kod bloğu.
                                                     //veri tabanında 's' takısı alır. Her kategoride birden fazla urun olabilir demek.
    }
}