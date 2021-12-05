using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollegeManagementServices.Data;
using CollegeManagementServices.Models;

namespace CollegeManagementServices.Controllers
{
    public class StaffTasksLogicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffTasksLogicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffTasksLogics
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffTasksLogics.ToListAsync());
        }

        // GET: StaffTasksLogics/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTasksLogic = await _context.StaffTasksLogics
                .FirstOrDefaultAsync(m => m.Code == id);
            if (staffTasksLogic == null)
            {
                return NotFound();
            }

            return View(staffTasksLogic);
        }

        // GET: StaffTasksLogics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffTasksLogics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Description,Location,Status")] StaffTasksLogic staffTasksLogic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffTasksLogic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffTasksLogic);
        }

        // GET: StaffTasksLogics/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTasksLogic = await _context.StaffTasksLogics.FindAsync(id);
            if (staffTasksLogic == null)
            {
                return NotFound();
            }
            return View(staffTasksLogic);
        }

        // POST: StaffTasksLogics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Description,Location,Status")] StaffTasksLogic staffTasksLogic)
        {
            if (id != staffTasksLogic.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffTasksLogic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffTasksLogicExists(staffTasksLogic.Code))
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
            return View(staffTasksLogic);
        }

        // GET: StaffTasksLogics/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffTasksLogic = await _context.StaffTasksLogics
                .FirstOrDefaultAsync(m => m.Code == id);
            if (staffTasksLogic == null)
            {
                return NotFound();
            }

            return View(staffTasksLogic);
        }

        // POST: StaffTasksLogics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var staffTasksLogic = await _context.StaffTasksLogics.FindAsync(id);
            _context.StaffTasksLogics.Remove(staffTasksLogic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffTasksLogicExists(string id)
        {
            return _context.StaffTasksLogics.Any(e => e.Code == id);
        }
    }
}
