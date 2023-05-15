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
    public class TaskCategoryController : ControllerBase
    {
        private readonly TaskManagementSystemContext _context;

        public TaskCategoryController(TaskManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/TaskCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskCategory>>> GetTaskCategories()
        {
            if (_context.TaskCategories == null)
            {
                return NotFound();
            }
            return await _context.TaskCategories.ToListAsync();
        }

        // GET: api/TaskCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskCategory>> GetTaskCategory(int id)
        {
            if (_context.TaskCategories == null)
            {
                return NotFound();
            }
            var taskCategory = await _context.TaskCategories.FindAsync(id);

            if (taskCategory == null)
            {
                return NotFound();
            }

            return taskCategory;
        }

        // PUT: api/TaskCategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskCategory(int id, TaskCategory taskCategory)
        {
            if (id != taskCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskCategoryExists(id))
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

        // POST: api/TaskCategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskCategory>> PostTaskCategory(TaskCategory taskCategory)
        {
            if (_context.TaskCategories == null)
            {
                return Problem("Entity set 'TaskManagementSystemContext.TaskCategories'  is null.");
            }
            _context.TaskCategories.Add(taskCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskCategory", new { id = taskCategory.Id }, taskCategory);
        }

        // DELETE: api/TaskCategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskCategory(int id)
        {
            if (_context.TaskCategories == null)
            {
                return NotFound();
            }
            var taskCategory = await _context.TaskCategories.FindAsync(id);
            if (taskCategory == null)
            {
                return NotFound();
            }

            _context.TaskCategories.Remove(taskCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskCategoryExists(int id)
        {
            return (_context.TaskCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
