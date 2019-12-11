using System;
using System.Collections.Generic;

namespace PizzaAwesomeApi.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            Sklada = new HashSet<Sklada>();
        }

        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }

        public virtual ICollection<Sklada> Sklada { get; set; }
    }
}
