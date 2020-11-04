using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreDrugSystem.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Drug> Drugs { get; set; }
        public Company()
        {
            Drugs = new List<Drug>();
        }
    }
}
