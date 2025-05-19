using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    [Table("Randevular")]
    public class Randevular
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(50), Required]
        public string RandevuAsistan { get; set; }

        [StringLength(50), Required]
        public string RandevuOgretimUyesi { get; set; }

        public DateTime RandevuTarihi { get; set; }
    }
}