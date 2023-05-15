using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Data.MODEL;
using TMS.Model;

namespace TMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTypeController : BaseApiController
    {
        private readonly TaskManagementSystemContext _context;

        public ReportTypeController(TaskManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/ReportType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportTypeMaster>>> GetReportTypeMasters()
        {
          if (_context.ReportTypeMasters == null)
          {
              return NotFound();
          }
            return await _context.ReportTypeMasters.ToListAsync();
        }

        // GET: api/ReportType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportTypeMaster>> GetReportTypeMaster(int id)
        {
          if (_context.ReportTypeMasters == null)
          {
              return NotFound();
          }
            var reportTypeMaster = await _context.ReportTypeMasters.FindAsync(id);

            if (reportTypeMaster == null)
            {
                return NotFound();
            }

            return reportTypeMaster;
        }

        // PUT: api/ReportType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportTypeMaster(int id, ReportTypeMaster reportTypeMaster)
        {
            if (id != reportTypeMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportTypeMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportTypeMasterExists(id))
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

        // POST: api/ReportType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportTypeMaster>> PostReportTypeMaster(ReportTypeMaster reportTypeMaster)
        {
          if (_context.ReportTypeMasters == null)
          {
              return Problem("Entity set 'TaskManagementSystemContext.ReportTypeMasters'  is null.");
          }
            _context.ReportTypeMasters.Add(reportTypeMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReportTypeMaster", new { id = reportTypeMaster.Id }, reportTypeMaster);
        }

        // DELETE: api/ReportType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportTypeMaster(int id)
        {
            if (_context.ReportTypeMasters == null)
            {
                return NotFound();
            }
            var reportTypeMaster = await _context.ReportTypeMasters.FindAsync(id);
            if (reportTypeMaster == null)
            {
                return NotFound();
            }

            _context.ReportTypeMasters.Remove(reportTypeMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportTypeMasterExists(int id)
        {
            return (_context.ReportTypeMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
