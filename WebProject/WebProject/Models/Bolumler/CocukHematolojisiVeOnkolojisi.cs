using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models.Bolumler
{
    [Table("CocukHematolojisiVeOnkolojisi")]
    public class CocukHematolojisiVeOnkolojisi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50), Required]
        public string OgretimUyesi { get; set; }
        [StringLength(50), Required]
        public string NobetciAsistan { get; set; }
        [Required]
        public int YatakSayisi { get; set; }
        [Required]
        public int BosYatakSayisi { get; set; }
    }
}