using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaAwesomeApi.Models;

namespace PizzaAwesomeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        s17006Context _context;
        public PizzaController(s17006Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPizza()
        {
            return Ok(_context.Pizza.Join(_context.Rodzaj, p => p.IdRodzaj, r => r.IdRodzaj, (p,r)=> new {Nazwa = p.Nazwa , Rodzaj = r.Nazwa, Cena = p.Cena }));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPizza(int id)
        {
            var pizza = _context.Pizza.Where(i => i.IdPizza == id).Join(_context.Rodzaj, p => p.IdRodzaj, r => r.IdRodzaj, (p, r) => new { Nazwa = p.Nazwa, Rodzaj = r.Nazwa, Cena = p.Cena }).FirstOrDefault();
            Console.WriteLine(pizza);
            if (pizza == null)
            {
                return NotFound();
            }
            else return Ok(pizza);
        }
  /*      [HttpGet("{id:int}/zamowienie")]
        public IActionResult GetPizzaZ(int id)
        {
            var pizza = _context.Pizza.Join(_context.Zamowienie, p => p.IdPizza, z => z.IdPizza, (p, z) => new { p, z })
                                      .Join(_context.Klient, zk => zk.z.IdKlient, k => k.IdKlient, (kz, k) => new { 
                                      ProdId = p.IdPizza,
                                      KlientId = k.IdKlient
                                      });


            return Ok(pizza);
        }*/

    }
}
/*
 * Scaffold-DbContext "Data Source=db-mssql;Initial Catalog=s17006;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -t Skladnik,Rodzaj,Pizza,SkladnikPizza,Klient,Pracownik,Zamowienie, Sklada
 * 
 */
