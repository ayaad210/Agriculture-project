using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agriculture_projectv1.Models;
using System.ComponentModel.DataAnnotations;

namespace Agriculture_projectv1.Models
{

    public partial class Compony
    {
        public Compony()
        {
            this.CrossTypes = new HashSet<CrossType>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<CrossType> CrossTypes { get; set; }
    }
    public partial class CrossType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CrossType()
        {
            this.Consultes = new HashSet<Consulte>();
            this.Componies = new HashSet<Compony>();
        }

        public int id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string seasons { get; set; }
        public Nullable<decimal> Duration { get; set; }
        public string Pesticidesdates { get; set; }
        public string Notes { get; set; }
        
        public virtual ICollection<Consulte> Consultes { get; set; }
        public virtual ICollection<Compony> Componies { get; set; }
    }
    public partial class Fertilizer
    {
        public Fertilizer()
        {
            this.Consultes = new HashSet<Consulte>();
        }

        public int id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Consulte> Consultes { get; set; }
    }
    public partial class Governorate
    {
        public Governorate()
        {
            this.Consultes = new HashSet<Consulte>();
        }

        public int id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Consulte> Consultes { get; set; }
    }
    public partial class SoilType
    {
        public SoilType()
        {
            this.Consultes = new HashSet<Consulte>();
        }

        public int id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Consulte> Consultes { get; set; }
    }
    public partial class Consulte
    {
        public Consulte()
        {
            this.Fertilizers = new HashSet<Fertilizer>();
            this.CrossTypes = new HashSet<CrossType>();
        }

        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SoilTypeId { get; set; }
        public int GoverorenatId { get; set; }
        public decimal AreaOfSoil { get; set; }
        public string Notes { get; set; }
        public string Response { get; set; }

        public virtual Governorate Governorate { get; set; }
        public virtual SoilType SoilType { get; set; }
        public virtual ICollection<Fertilizer> Fertilizers { get; set; }
        public virtual ICollection<CrossType> CrossTypes { get; set; }
    }


    public partial class Contact
    {
       
        public int id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

    }













}