using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenDucThanh_2310900098.Models;

namespace NguyenDucThanh_2310900098.Controllers
{
    public class NdtEmployeesController : Controller
    {
        private readonly NguyenDucThanh2310900098Context _context;

        public NdtEmployeesController(NguyenDucThanh2310900098Context context)
        {
            _context = context;
        }

        // GET: NdtEmployees
        public async Task<IActionResult> NdtIndex()
        {
            return View(await _context.NdtEmployees.ToListAsync());
        }

        // GET: NdtEmployees/NdtDetails/5
        public async Task<IActionResult> NdtDetails(int? ndtId)
        {
            if (ndtId == null)
            {
                return NotFound();
            }

            var ndtEmployee = await _context.NdtEmployees
                .FirstOrDefaultAsync(m => m.NdtEmpId == ndtId);
            if (ndtEmployee == null)
            {
                return NotFound();
            }

            return View(ndtEmployee);
        }

        // GET: NdtEmployees/NdtCreate
        public IActionResult NdtCreate()
        {
            return View();
        }

        // POST: NdtEmployees/NdtCreate
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NdtCreate([Bind("NdtEmpId,NdtEmpName,NdtEmpLevel,NdtEmpStartDate,NdtEmpStatus")] NdtEmployee ndtEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ndtEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NdtIndex));
            }
            return View(ndtEmployee);
        }

        // GET: NdtEmployees/NdtEdit/5
        public async Task<IActionResult> NdtEdit(int? ndtId)
        {
            if (ndtId == null)
            {
                return NotFound();
            }

            var ndtEmployee = await _context.NdtEmployees.FindAsync(ndtId);
            if (ndtEmployee == null)
            {
                return NotFound();
            }
            return View(ndtEmployee);
        }

        // POST: NdtEmployees/NdtEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NdtEdit(int ndtId, [Bind("NdtEmpId,NdtEmpName,NdtEmpLevel,NdtEmpStartDate,NdtEmpStatus")] NdtEmployee ndtEmployee)
        {
            if (ndtId != ndtEmployee.NdtEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ndtEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NdtEmployeeExists(ndtEmployee.NdtEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NdtIndex));
            }
            return View(ndtEmployee);
        }

        // GET: NdtEmployees/Delete/5
        public async Task<IActionResult> NdtDelete(int? ndtId)
        {
            if (ndtId == null)
            {
                return NotFound();
            }

            var ndtEmployee = await _context.NdtEmployees
                .FirstOrDefaultAsync(m => m.NdtEmpId == ndtId);
            if (ndtEmployee == null)
            {
                return NotFound();
            }

            return View(ndtEmployee);
        }

        // POST: NdtEmployees/NdtDelete/5
        [HttpPost, ActionName("NdtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ndtId)
        {
            var ndtEmployee = await _context.NdtEmployees.FindAsync(ndtId);
            if (ndtEmployee != null)
            {
                _context.NdtEmployees.Remove(ndtEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NdtIndex));
        }

        private bool NdtEmployeeExists(int ndtId)
        {
            return _context.NdtEmployees.Any(e => e.NdtEmpId == ndtId);
        }
    }
}
