using System;
using System.Collections.Generic;

namespace PizzaAwesomeApi.Models
{
    public partial class Sklada
    {
        public int IdZamowienie { get; set; }
        public int IdPracownik { get; set; }
        public int IdZlozenia { get; set; }

        public virtual Pracownik IdPracownikNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
