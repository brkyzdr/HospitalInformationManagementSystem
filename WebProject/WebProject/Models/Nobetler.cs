using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    [Table("Nobetler")]
    public class Nobetler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        

        [StringLength(50), Required]
        public string NobetBolumu { get; set; }

        [StringLength(50), Required]
        public string NobetciAsistan { get; set; }
        public DateTime NobetTarihi { get; set; }

    }
}