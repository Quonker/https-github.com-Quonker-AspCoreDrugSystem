using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Drug
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tradename not specified")]
        
        public string Tradename { get; set; }
      

        // New
      //  [Required(ErrorMessage = "Url of picture not specified")]
        public string UmageUrl { get; set; }
        public string NonProprietaryName { get; set; }
        public string Description { get; set; }
        public string Composition { get; set; }
        public string PharmacotherapeuticGroup { get; set; } //?
        public string PharmacotherapeuticProperties { get; set; }


        public string CodeATX { get; set; }
        public string ClinicalPharmacology { get; set; }
        public string Indications { get; set; }
        public string Usage { get; set; }
        public string Contraindications { get; set; }
        public string Warnings { get; set; }

        public string Precautions { get; set; }

        public string AdverseReactions { get; set; }

        public string Dependence { get; set; }
        public string Overdosage { get; set; }
        public string Dosage { get; set; }
        public string HowSupplied { get; set; }

        // Navig
        [Required(ErrorMessage = "Company not specified")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        
    }
}
