using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaAwesomeApi.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }
        [Key]
        public int IdKlient { get; set; }
        public string Imie { get; set; }
        public string NrTelefonu { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
