using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    [Table("Duyurular")]
    public class Duyurular
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(5000), Required]
        public string DuyuruMetni { get; set; }

        public DateTime Date { get; set; }
    }
}