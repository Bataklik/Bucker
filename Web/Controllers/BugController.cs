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
    [Route("api/bugs")]
    [ApiController]
    public class BugController : ControllerBase {
        private readonly IBugService _service;

        public BugController(IBugService service) {
            _service = service;
        }

        // GET: api/Bugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bug>>> GetBugs() {
            var bugs = await _service.GetBugsDbAsync();
            return Ok(bugs);
        }

        // GET: api/Bugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetBug(int id) {
            var bug = await _service.GetBugDbAsync(id);

            if (bug.Equals(null)) {
                return NotFound();
            }

            return bug;
        }

        // PUT: api/Bugs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBug(int id, Bug bug) {
            if (id != bug.Id) {
                return BadRequest();
            }

            var isOk = await _service.UpdateBugAsync(bug);

            if (!isOk) {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Bugs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bug>> PostBug(Bug bug) {
           
            var createdBug = await _service.CreateBugAsync(bug);
            return CreatedAtAction(nameof(GetBug), new{ id = createdBug.Id }, createdBug);
        }

        // DELETE: api/Bugs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBug(int id) {
            var isDeleted = await _service.DeleteBugAsync(id);
            if (!isDeleted) {
                return NotFound();
            }

            return NoContent();
        }

        private bool BugExists(int id) {
            return _service.BugExists(id);
        }
    }
}