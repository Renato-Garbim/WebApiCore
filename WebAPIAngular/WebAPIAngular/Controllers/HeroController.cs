using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPIAngular.Custom;
using WebAPIAngular.Models;

namespace WebAPIAngular.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly HeroAngular _context;

        public HeroController(HeroAngular context)
        {
            _context = context;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    var registros = _context.Set<Hero>().AsEnumerable();

        //    //registros.Json.

        //    return registros;
        //}

        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _context.Set<Hero>().AsEnumerable();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Hero>> Post(Hero item)
        {
            _context.Hero.Add(item);

            await _context.SaveChangesAsync();

            return Ok();
        }


        // GET: api/Hero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> Get(int id)
        {
            var hero = await _context.FindAsync<Hero>(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, Hero item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _context.Hero.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            _context.Hero.Remove(hero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}