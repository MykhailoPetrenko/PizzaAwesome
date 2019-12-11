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
    public class KlientController : ControllerBase
    {
        s17006Context _context;
        public KlientController(s17006Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetKlients() {
            return Ok(_context.Klient.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetKlients(int id)
        {
            var klient = _context.Klient.Where(i => i.IdKlient == id).FirstOrDefault();
            if (klient == null)
                return NotFound();
            return Ok(klient);
        }

    }
}