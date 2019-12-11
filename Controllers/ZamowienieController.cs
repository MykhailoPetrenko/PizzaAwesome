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
    public class ZamowienieController : ControllerBase
    {
        s17006Context _context;
        public ZamowienieController(s17006Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetZamowienie()
        {
            return Ok(_context.Zamowienie.ToList());
        }
    }
}