using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NdtLesoon10FE.Models;

namespace NdtLesoon10FE.Controllers
{
    public class NdtCategoriesController : Controller
    {
        private readonly NdtK23cnt2lesson10Context _context;

        public NdtCategoriesController(NdtK23cnt2lesson10Context context)
        {
            _context = context;
        }

        // GET: NdtCategories
        public async Task<IActionResult> NdtIndex()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NdtCategories/Details/5
        public async Task<IActionResult> NdtDetails(int? ndtId)
        {
            if (ndtId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == ndtId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NdtCategories/NdtCreate
        public IActionResult NdtCreate()
        {
            return View();
        }

        // POST: NdtCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NdtCreate([Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NdtIndex));
            }
            return View(category);
        }

        // GET: NdtCategories/NdtEdit/5
        public async Task<IActionResult> NdtEdit(int? ndtId)
        {
            if (ndtId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(ndtId);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NdtCategories/NdtEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NdtEdit(int ndtId, [Bind("CateId,CateName,CateStatus")] Category category)
        {
            if (ndtId != category.CateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CateId))
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
            return View(category);
        }

        // GET: NdtCategories/NdtDelete/5
        public async Task<IActionResult> NdtDelete(int? ndtId)
        {
            if (ndtId == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CateId == ndtId);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NdtCategories/NdtDelete/5
        [HttpPost, ActionName("NdtDelete    ")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ndtId)
        {
            var category = await _context.Categories.FindAsync(ndtId);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NdtIndex));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CateId == id);
        }
    }
}
