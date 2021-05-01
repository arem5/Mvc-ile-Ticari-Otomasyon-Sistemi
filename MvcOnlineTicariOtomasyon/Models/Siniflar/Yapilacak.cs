using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacak
    {
        [Key]
        public int YapilacakId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Column(TypeName="bit")]
        public bool Durum { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SonTarih { get; set; }
    }
}