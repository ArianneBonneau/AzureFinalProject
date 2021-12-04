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
    public class StudentTasksLogicsController : Controller
    {
        private readonly CollegeManagementServicesContext _context;

        public StudentTasksLogicsController(CollegeManagementServicesContext context)
        {
            _context = context;
        }

        // GET: StudentTasksLogics
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentTasksLogics.ToListAsync());
        }

        // GET: StudentTasksLogics/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTasksLogic = await _context.StudentTasksLogics
                .FirstOrDefaultAsync(m => m.Code == id);
            if (studentTasksLogic == null)
            {
                return NotFound();
            }

            return View(studentTasksLogic);
        }

        // GET: StudentTasksLogics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentTasksLogics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Description,Status")] StudentTasksLogic studentTasksLogic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTasksLogic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTasksLogic);
        }

        // GET: StudentTasksLogics/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTasksLogic = await _context.StudentTasksLogics.FindAsync(id);
            if (studentTasksLogic == null)
            {
                return NotFound();
            }
            return View(studentTasksLogic);
        }

        // POST: StudentTasksLogics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Description,Status")] StudentTasksLogic studentTasksLogic)
        {
            if (id != studentTasksLogic.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTasksLogic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTasksLogicExists(studentTasksLogic.Code))
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
            return View(studentTasksLogic);
        }

        // GET: StudentTasksLogics/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTasksLogic = await _context.StudentTasksLogics
                .FirstOrDefaultAsync(m => m.Code == id);
            if (studentTasksLogic == null)
            {
                return NotFound();
            }

            return View(studentTasksLogic);
        }

        // POST: StudentTasksLogics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var studentTasksLogic = await _context.StudentTasksLogics.FindAsync(id);
            _context.StudentTasksLogics.Remove(studentTasksLogic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTasksLogicExists(string id)
        {
            return _context.StudentTasksLogics.Any(e => e.Code == id);
        }
    }
}
