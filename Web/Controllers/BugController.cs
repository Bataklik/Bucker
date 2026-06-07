using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

// https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver17&tabs=cli&pivots=cs1-bash
// https://hub.docker.com/r/zabbix/zabbix-server-mysql

namespace Web.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase {
        private readonly IBugService _service;

        public BugController(IBugService service) {
            _service = service;
        }

        // GET: api/Bug
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bug>>> GetBug() {
            var bugs = await _service.getBugsDbAsync();
            return Ok(bugs);
        }

        // GET: api/Bug/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetBug(int id) {
            var bug = await _context.Bugs.FindAsync(id);

            if (bug == null) {
                return NotFound();
            }

            return bug;
        }

        // PUT: api/Bug/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBug(Guid id, Bug bug) {
            if (id != bug.Id) {
                return BadRequest();
            }

            _context.Entry(bug).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!BugExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bug
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bug>> PostBug(Bug bug) {
            _context.Bugs.Add(bug);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBug", new{ id = bug.Id }, bug);
        }

        // DELETE: api/Bug/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBug(int id) {
            var bug = await _context.Bugs.FindAsync(id);
            if (bug == null) {
                return NotFound();
            }

            _context.Bugs.Remove(bug);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BugExists(Guid id) {
            return _context.Bugs.Any(e => e.Id == id);
        }
    }
}