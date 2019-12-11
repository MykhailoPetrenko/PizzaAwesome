using System;
using System.Collections.Generic;

namespace PizzaAwesomeApi.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            SkladnikPizza = new HashSet<SkladnikPizza>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }

        public virtual ICollection<SkladnikPizza> SkladnikPizza { get; set; }
    }
}
