using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAwesomeApi.Models;

namespace PizzaAwesomeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkladnikController : ControllerBase
    {
        s17006Context _context;
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
        [HttpDelete("delete/{id:int}")]
        public IActionResult DeleteSkladnik(int id)
        {
            var skladnik = _context.Skladnik.Where(i => i.IdSkladnik == id).FirstOrDefault();
            if (skladnik == null) return NotFound();
            _context.Skladnik.Remove(skladnik);
            _context.SaveChanges();
            return Ok(skladnik + " Zostal usuniety");
        }
    }
}