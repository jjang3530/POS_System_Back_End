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
    public class TablesController : ControllerBase
    {
        private readonly Dima3APIContext _context;

        public TablesController(Dima3APIContext context)
        {
            _context = context;
        }

        //GET: api/Tables
       [HttpGet]
        public IEnumerable<Tables> GetTables()
        {
            return _context.Tables;
            //.Include(o=>o.Orders);
        }
        
        // GET: api/Tables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTables([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var tables = await _context.Tables
            //    .Include(o => o.Orders)
            //    .FirstOrDefaultAsync(i => i.TableId == id);
                
              var tables = await _context.Tables.FindAsync(id);

            if (tables == null)
            {
                return NotFound();
            }

            return Ok(tables);
        }

        // PUT: api/Tables/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTables([FromRoute] int id, [FromBody] Tables tables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tables.TableId)
            {
                return BadRequest();
            }

            _context.Entry(tables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablesExists(id))
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

        // POST: api/Tables
        [HttpPost]
        public async Task<IActionResult> PostTables([FromBody] Tables tables)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tables.Add(tables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTables", new { id = tables.TableId }, tables);
        }

        // DELETE: api/Tables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTables([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tables = await _context.Tables.FindAsync(id);
            if (tables == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(tables);
            await _context.SaveChangesAsync();

            return Ok(tables);
        }

        private bool TablesExists(int id)
        {
            return _context.Tables.Any(e => e.TableId == id);
        }
    }
}