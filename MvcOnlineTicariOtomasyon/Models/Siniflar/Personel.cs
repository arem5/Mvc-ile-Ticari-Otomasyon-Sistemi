using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemesiniz.")]
        public string PersonelAd { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemesiniz.")]
        public string PersonelSoyad { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(40)]
        public string PersonelMahalle { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(40)]
        public string PersonelSokak { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(40)]
        public string PersonelApartmanKapiNo { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(40)]
        public string PersonelSemtSehir { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(11, ErrorMessage = "Başında 0 olarak 11 haneli şekilde giriniz.")]
        public string PersonelPhone { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(60, ErrorMessage = "Geçerli bir mail adresi giriniz.")]
        public string PersonelEmail { get; set; }


        public ICollection<SatisHaraket> SatisHarakets { get; set; }
        //bir personel yalnızca bir departmanda olabilir

        public bool Durum { get; set; }
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}