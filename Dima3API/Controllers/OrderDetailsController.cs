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
    public class OrderDetailsController : ControllerBase
    {
        private readonly Dima3APIContext _context;

        public OrderDetailsController(Dima3APIContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public IEnumerable<OrderDetail> GetOrderDetail()
        {
            return _context.OrderDetail.Include(o => o.menus).Include(m => m.orders);
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var getOrderDetail = await _context.OrderDetail.FindAsync(id);

            if (getOrderDetail == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetail
                .Include(o => o.menus)
                .FirstOrDefaultAsync(s => s.MenuId == getOrderDetail.MenuId);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        // PUT: api/OrderDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail([FromRoute] int id, [FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderDetail.OrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetails
        [HttpPost]
        public async Task<IActionResult> PostOrderDetail([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderDetail.Add(orderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.OrderDetailId }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetail.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return Ok(orderDetail);
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetail.Any(e => e.OrderDetailId == id);
        }
    }
}