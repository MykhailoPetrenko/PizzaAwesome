using System;
using System.Collections.Generic;

namespace PizzaAwesomeApi.Models
{
    public partial class Rodzaj
    {
        public Rodzaj()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdRodzaj { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
