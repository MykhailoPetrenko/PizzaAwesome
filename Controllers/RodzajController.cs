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
    public class RodzajController : ControllerBase
    {
        s17006Context _context;
        public RodzajController(s17006Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetRodazaj()
        {
            return Ok(_context.Rodzaj.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetRodzaj(int id)
        {
            var rodzaj = _context.Rodzaj.Where(i => i.IdRodzaj == id).FirstOrDefault();
            if (rodzaj == null) return NotFound();
            return Ok(rodzaj);
        }

    }
}