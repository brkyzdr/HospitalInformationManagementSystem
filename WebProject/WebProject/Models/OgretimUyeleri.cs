using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    [Table("OgretimUyeleri")]
    public class OgretimUyeleri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50), Required]
        public string Ad { get; set; }

        [StringLength(50), Required]
        public string Soyad { get; set; }

        [StringLength(50), Required]
        public string Mail { get; set; }

        [StringLength(50), Required]
        public string Telefon { get; set; }

        [StringLength(300), Required]
        public string Adres { get; set; }
    }
}