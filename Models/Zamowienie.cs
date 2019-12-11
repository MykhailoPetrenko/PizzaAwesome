using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaAwesomeApi.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            Sklada = new HashSet<Sklada>();
        }
        [ForeignKey("IdKlient")]
        public int IdKlient { get; set; }
        [ForeignKey("IdPizza")]
        public int IdPizza { get; set; }
        public string Adres { get; set; }
        public int CenaZamowienia { get; set; }
        [Key]
        public int IdZamowienie { get; set; }
        public DateTime Data { get; set; }

        public virtual Klient IdKlientNavigation { get; set; }
        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual ICollection<Sklada> Sklada { get; set; }
    }
}
