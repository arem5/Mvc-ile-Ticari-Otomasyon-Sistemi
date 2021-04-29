using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {   //Yalnız bir fatursı olabilir.
        [Key]
        public int FaturaKalemID { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public int Faturaid { get; set; }
        public virtual Faturalar Faturalar { get; set; }

    }
}