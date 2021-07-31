
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Agriculture_projectv1.Models
{
    public class CrossTypeViewModel
    {


        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public HttpPostedFileBase ImageFile{ get; set; }

        public string seasons { get; set; }
        [Required]
        public decimal Duration { get; set; }
        public string Pesticidesdates { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Compony> Componies { get; set; }

    }
}