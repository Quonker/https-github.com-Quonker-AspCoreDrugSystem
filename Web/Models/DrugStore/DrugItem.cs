using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Models;

namespace Web.Views.DrugStore
{
    public class DrugItem
    {
        public int Id { get; set; }
        [Range(1, 5000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int IsRecipeNeeded { get; set; }
        //public int DrugId { get; set; }
        //public Drug Drug { get; set; }
        //public int CompanyId { get; set; }
        //public Company Company { get; set; }
    }
}