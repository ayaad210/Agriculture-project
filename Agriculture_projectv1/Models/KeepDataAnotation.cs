using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agriculture_projectv1.Models;
using System.ComponentModel.DataAnnotations;

namespace Agriculture_projectv1.Models
{
  
        [MetadataType(typeof(Consultedataanotation))]

        public partial class Consulte
        {

        }
        class Consultedataanotation
        {
            [Required]
            public int SoilTypeId { get; set; }
            [Required]
            public int GoverorenatId { get; set; }
            [Required]
            public decimal AreaOfSoil { get; set; }

            public string Notes { get; set; }
            public string Response { get; set; }


        }

        [MetadataType(typeof(SoilTypedataanotation))]

        public partial class SoilType
        {

        }
        class SoilTypedataanotation
        {
            [Required]
            public string Name { get; set; }



        }

        [MetadataType(typeof(Governoratedataanotation))]
        public partial class Governorate
        {


        }

        class Governoratedataanotation
        {
            [Required]
            public string Name { get; set; }



        }



        [MetadataType(typeof(Componydataanotation))]
        public partial class  Compony
        {


        }

        class Componydataanotation
        {
            [Required]
            public string Name { get; set; }
            public string Address { get; set; }
            public string Link { get; set; }
            public string Notes { get; set; }
            public string Phone { get; set; }


        }

        [MetadataType(typeof(Fertilizerdataanotation))]
        public partial class Fertilizer
        {


        }

        class Fertilizerdataanotation
        {
            [Required]
            public string Name { get; set; }
         


        }



    
}