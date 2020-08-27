using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DrugViewModel> Drugs { get; set; }
        public CompanyViewModel()
        {
            Drugs = new List<DrugViewModel>();
        }
    }
}
