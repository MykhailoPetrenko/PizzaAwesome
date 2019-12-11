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
    public class SkladnikController : ControllerBase
    {
        private readonly s17006Context _context;//readonly - mozemy nadac wartosc tylko w kostr
        public SkladnikController(s17006Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetSkladnik()
        {
            return Ok(_context.Skladnik.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetSkladnik(int id)
        {
            var skladnik = _context.Skladnik.Where(i => i.IdSkladnik == id).FirstOrDefault();
            if (skladnik == null) return NotFound();
            return Ok(skladnik);
        }
  /*      [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteSkladnik(int id)
        {
            var skladnik = _context.Skladnik.Where(i => i.IdSkladnik == id).FirstOrDefault();
            if (skladnik == null) return NotFound();
            _context.Skladnik.Remove(skladnik);
            _context.SaveChanges();
            return Ok(skladnik + " Zostal usuniety");
        }*/
        [HttpPost]
        public IActionResult Create(Skladnik newSkladnik)
        {
            _context.Skladnik.Add(newSkladnik);
            _context.SaveChanges();

            return StatusCode(201, newSkladnik);
        }
        [HttpPut]
        public IActionResult Update(Skladnik updateSkladnik)
        {
                        if (_context.Skladnik.Count(s => s.IdSkladnik == updateSkladnik.IdSkladnik) != 1) return NotFound();
            _context.Skladnik.Attach(updateSkladnik);
            _context.Entry(updateSkladnik).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updateSkladnik);
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(i => i.IdSkladnik == id);
            if (skladnik == null) return NotFound();
            _context.Skladnik.Remove(skladnik);
            _context.SaveChanges();
            return Ok(skladnik);
        }
    }
}
