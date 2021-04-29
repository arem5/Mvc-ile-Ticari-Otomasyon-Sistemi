using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Departman
    {//Bir departman birden fazla personel de olabilr
        [Key]
        public int DepartmanID { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "VarChar")]
        [StringLength(30,ErrorMessage ="Bu alan en fazla 30 karakter içermeli.")]
        [Required(ErrorMessage = "Bu alanı girmek zorundasınız.")]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }
}