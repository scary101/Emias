using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API6.Models;

namespace API6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDocumentsController : ControllerBase
    {
        private readonly pract100Context _context;

        public AppointmentDocumentsController(pract100Context context)
        {
            _context = context;
        }

        // GET: api/AppointmentDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDocument>>> GetAppointmentDocuments()
        {
          if (_context.AppointmentDocuments == null)
          {
              return NotFound();
          }
            return await _context.AppointmentDocuments.ToListAsync();
        }

        // GET: api/AppointmentDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDocument>> GetAppointmentDocument(int? id)
        {
          if (_context.AppointmentDocuments == null)
          {
              return NotFound();
          }
            var appointmentDocument = await _context.AppointmentDocuments.FindAsync(id);

            if (appointmentDocument == null)
            {
                return NotFound();
            }

            return appointmentDocument;
        }

        // PUT: api/AppointmentDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointmentDocument(int? id, AppointmentDocument appointmentDocument)
        {
            if (id != appointmentDocument.Appid)
            {
                return BadRequest();
            }

            _context.Entry(appointmentDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentDocumentExists(id))
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

        // POST: api/AppointmentDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentDocument>> PostAppointmentDocument(AppointmentDocument appointmentDocument)
        {
          if (_context.AppointmentDocuments == null)
          {
              return Problem("Entity set 'pract100Context.AppointmentDocuments'  is null.");
          }
            _context.AppointmentDocuments.Add(appointmentDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointmentDocument", new { id = appointmentDocument.Appid }, appointmentDocument);
        }

        // DELETE: api/AppointmentDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentDocument(int? id)
        {
            if (_context.AppointmentDocuments == null)
            {
                return NotFound();
            }
            var appointmentDocument = await _context.AppointmentDocuments.FindAsync(id);
            if (appointmentDocument == null)
            {
                return NotFound();
            }

            _context.AppointmentDocuments.Remove(appointmentDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentDocumentExists(int? id)
        {
            return (_context.AppointmentDocuments?.Any(e => e.Appid == id)).GetValueOrDefault();
        }
    }
}
