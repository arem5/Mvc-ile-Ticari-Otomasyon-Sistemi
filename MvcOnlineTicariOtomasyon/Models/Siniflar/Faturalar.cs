using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {   //one-to-many bir faturanın birden çok kalemi olabilir.
        [Key]
        public int FaturaID { get; set; }

        //string ad için sınırlama getirdik,sqlde çok yüksek hafıza kaplardı yoksa
        [Column(TypeName = "Char")]
        [StringLength(1)]       //Harf olacak
        public string FaturaSeriNo { get; set; }

 
        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        public DateTime FaturaTarih { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string FaturaSaat { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }

        public decimal ToplamTutar { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; } 


    }
}