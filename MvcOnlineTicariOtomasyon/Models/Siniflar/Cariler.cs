using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "VarChar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemesiniz.")]
        [Display(Name = "İsim")]
        public string CariAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage ="Bu alanı boş geçemesiniz.")]
        [Display(Name = "Soyisim")]
        public string CariSoyad { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(13,ErrorMessage = "En fazla 13 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemesiniz.")]
        [Display(Name = "Şehir")]
        public string CariSehir { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter yazabilirsiniz.")]
        [Display(Name = "Email")]
        public string CariMail { get; set; }

        public bool Durum { get; set; }
        public ICollection<SatisHaraket> SatisHarakets { get; set; }
    }
}