using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaAwesomeApi.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            SkladnikPizza = new HashSet<SkladnikPizza>();
            Zamowienie = new HashSet<Zamowienie>();
        }
        [Key]
        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public int IdRodzaj { get; set; }
        public int Cena { get; set; }

        public virtual Rodzaj IdRodzajNavigation { get; set; }
        public virtual ICollection<SkladnikPizza> SkladnikPizza { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
