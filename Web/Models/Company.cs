using System.Collections.Generic;

namespace Web.Models
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