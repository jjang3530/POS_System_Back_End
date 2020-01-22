using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dima3API.Data;
using Dima3API.Models;
using Microsoft.AspNetCore.Cors;

namespace Dima3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MenusController : ControllerBase
    {
        private readonly Dima3APIContext _context;

        public MenusController(Dima3APIContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public IEnumerable<Menus> GetMenus()
        {
            return _context.Menus;
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var menus = await _context.Menus.FindAsync(id);

            var menus = await _context.Menus
                .FirstOrDefaultAsync(s => s.MenuId == id);

            if (menus == null)
            {
                return NotFound();
            }

            return Ok(menus);
        }

        // PUT: api/Menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenus([FromRoute] int id, [FromBody] Menus menus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menus.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Menus
        [HttpPost]
        public async Task<IActionResult> PostMenus([FromBody] Menus menus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Menus.Add(menus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenus", new { id = menus.MenuId }, menus);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menus = await _context.Menus.FindAsync(id);
            if (menus == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menus);
            await _context.SaveChangesAsync();

            return Ok(menus);
        }

        private bool MenusExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}