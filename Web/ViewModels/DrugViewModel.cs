using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class DrugViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tradename not specified")]

        public string Tradename { get; set; }


        // New
        //  [Required(ErrorMessage = "Url of picture not specified")]
        public string Path { get; set; }
   
        public string Description { get; set; }
       

        // Navig
        [Required(ErrorMessage = "Company not specified")]
        public int CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
    }
}
