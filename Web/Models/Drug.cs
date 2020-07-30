using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Drug
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tradename not specified")]
        
        public string Tradename { get; set; }
        [Required(ErrorMessage = "Price not specified")]
        [RegularExpression(@"^\d*(\.\d{0,2})?$", ErrorMessage = "Incorrect input")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Company not specified")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        
    }
}
