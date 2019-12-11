using System;
using System.Collections.Generic;

namespace PizzaAwesomeApi.Models
{
    public partial class SkladnikPizza
    {
        public int IdPizza { get; set; }
        public int IdSkladnik { get; set; }
        public int IdSkladnikPizza { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
    }
}
