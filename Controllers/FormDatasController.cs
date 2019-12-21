using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HD_Decisions_Case_Study.Data;
using HD_Decisions_Case_Study.Models;
using Microsoft.AspNetCore.Authorization;


namespace HD_Decisions_Case_Study.Controllers
{
    public class FormDatasController : Controller
    {
        private readonly HD_Decisions_Case_StudyContext _context;
        

        public FormDatasController(HD_Decisions_Case_StudyContext context)
        {
            _context = context;
        }

        // GET: FormDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormData.ToListAsync());
        }

        // GET: FormDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formData = await _context.FormData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formData == null)
            {
                return NotFound();
            }

            return View(formData);
        }

        // GET: FormDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormDatas/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(int AnnualIncome, [Bind("Id,Name,AnnualIncome,DateOfBirth")] FormData formData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formData);
                await _context.SaveChangesAsync();

            }
            
            if (AnnualIncome >= 30001)
            {
                return View("Barclaycard");
            }

            else
            {
                return View("Vanquis");
            }
            


        }

        // GET: FormDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formData = await _context.FormData.FindAsync(id);
            if (formData == null)
            {
                return NotFound();
            }
            return View(formData);
        }

        // POST: FormDatas/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AnnualIncome,DateOfBirth")] FormData formData)
        {
            if (id != formData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormDataExists(formData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(formData);
        }

        // GET: FormDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formData = await _context.FormData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formData == null)
            {
                return NotFound();
            }

            return View(formData);
        }

        // POST: FormDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formData = await _context.FormData.FindAsync(id);
            _context.FormData.Remove(formData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
      

        private bool FormDataExists(int id)
        {
            return _context.FormData.Any(e => e.Id == id);
        }
    }
}
