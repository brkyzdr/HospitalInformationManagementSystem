using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebProject.Models;
using WebProject.Models.Bolumler;

namespace WebProject.Models.Bolumler
{
    public class Bolum
    {
        public List<CocukAcil> CocukAcil { get; set; }
        public List<CocukHematolojisiVeOnkolojisi> CocukHematolojisiVeOnkolojisi { get; set; }
        public List<CocukYogunBakim> CocukYogunBakim { get; set; }
    }
}