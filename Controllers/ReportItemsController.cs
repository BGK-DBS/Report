#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReportWebApi.Models;

// start 
namespace ReportWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportItemsController : ControllerBase
    {
        private readonly ReportContext _context;

        public ReportItemsController(ReportContext context)
        {
            _context = context;
        }

        // GET: api/ReportItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportItem>>> GetReportItems()
        {
            return await _context.ReportItem.ToListAsync();
        }

        // Purpose - return a list of reports with the following filtering:
        //   all reports or the logged in user reports only
        //   All categories or from a particular category
        //   

        //GET: api/ReportItems/FilterReports?creationEmail?={creationEmail}&category?={category}
        [HttpGet("FilterReports")]
        public async Task<ActionResult<IEnumerable<ReportItem>>> GetReportFilteredItems([FromQuery]string creationEmail, [FromQuery]string category)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> CategoryQuery = from m in _context.ReportItem
                                               orderby m.Category
                                               select m.Category;

            var reports = from m in _context.ReportItem
                          select m;

            if (!string.IsNullOrEmpty(category))
            {
                reports = reports.Where(s => s.Category == category);
            }

            if (!string.IsNullOrEmpty(creationEmail))
            {
                reports = reports.Where(x => x.CreationEmail == creationEmail);
            }

            var ReportCategoryVM = new ReportCategoryViewModel
            {
                Categories = new SelectList(await CategoryQuery.Distinct().ToListAsync()),
                Reports = await reports.ToListAsync()
            };

            return ReportCategoryVM.Reports;
        }

        // GET: api/ReportItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportItem>> GetReportItem(int id)
        {
            var reportItem = await _context.ReportItem.FindAsync(id);

            if (reportItem == null)
            {
                return NotFound();
            }

            return reportItem;
        }

        // PUT: api/ReportItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportItem(int id, ReportItem reportItem)
        {
            if (id != reportItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(reportItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportItemExists(id))
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

        // POST: api/ReportItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReportItem>> PostReportItem(ReportItem reportItem)
        {
            _context.ReportItem.Add(reportItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReportItem), new { id = reportItem.Id }, reportItem);
        }

        // DELETE: api/ReportItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportItem(int id)
        {
            var reportItem = await _context.ReportItem.FindAsync(id);
            if (reportItem == null)
            {
                return NotFound();
            }

            _context.ReportItem.Remove(reportItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportItemExists(int id)
        {
            return _context.ReportItem.Any(e => e.Id == id);
        }
    }
}
