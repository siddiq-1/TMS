using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Data.MODEL;
using TMS.Model;

namespace TMS.API.Controllers.Task
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly TaskManagementSystemContext _context;

        public TaskStatusController(TaskManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/TaskStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskStatusMaster>>> GetTaskStatusMasters()
        {
            if (_context.TaskStatusMasters == null)
            {
                return NotFound();
            }
            return await _context.TaskStatusMasters.ToListAsync();
        }

        // GET: api/TaskStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskStatusMaster>> GetTaskStatusMaster(int id)
        {
            if (_context.TaskStatusMasters == null)
            {
                return NotFound();
            }
            var taskStatusMaster = await _context.TaskStatusMasters.FindAsync(id);

            if (taskStatusMaster == null)
            {
                return NotFound();
            }

            return taskStatusMaster;
        }

        // PUT: api/TaskStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskStatusMaster(int id, TaskStatusMaster taskStatusMaster)
        {
            if (id != taskStatusMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskStatusMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskStatusMasterExists(id))
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

        // POST: api/TaskStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskStatusMaster>> PostTaskStatusMaster(TaskStatusMaster taskStatusMaster)
        {
            if (_context.TaskStatusMasters == null)
            {
                return Problem("Entity set 'TaskManagementSystemContext.TaskStatusMasters'  is null.");
            }
            _context.TaskStatusMasters.Add(taskStatusMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskStatusMaster", new { id = taskStatusMaster.Id }, taskStatusMaster);
        }

        // DELETE: api/TaskStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskStatusMaster(int id)
        {
            if (_context.TaskStatusMasters == null)
            {
                return NotFound();
            }
            var taskStatusMaster = await _context.TaskStatusMasters.FindAsync(id);
            if (taskStatusMaster == null)
            {
                return NotFound();
            }

            _context.TaskStatusMasters.Remove(taskStatusMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskStatusMasterExists(int id)
        {
            return (_context.TaskStatusMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
