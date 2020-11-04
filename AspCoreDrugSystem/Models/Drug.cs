using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreDrugSystem.Models
{
    public class Drug
    {
        [Key ,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrugId { get; set; }
        [Required]

        public string Tradename { get; set; }

        //public string Path { get; set; }
        //public string Description { get; set; }

        //// Navig
        //[Required]
        //public int CompanyId { get; set; }
        ////public Company Company { get; set; }

    }
}
