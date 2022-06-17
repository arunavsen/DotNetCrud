using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCrud.Models;

namespace DotNetCrud.Controllers
{
    public class EmployessesController : Controller
    {
        private readonly DotNet5crudContext _context;

        public EmployessesController(DotNet5crudContext context)
        {
            _context = context;
        }

        // GET: Employesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employesses.ToListAsync());
        }

        // GET: Employesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employess = await _context.Employesses
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employess == null)
            {
                return NotFound();
            }

            return View(employess);
        }

        // GET: Employesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Address,Designation,Salary,JoiningDate")] Employess employess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employess);
        }

        // GET: Employesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employess = await _context.Employesses.FindAsync(id);
            if (employess == null)
            {
                return NotFound();
            }
            return View(employess);
        }

        // POST: Employesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Address,Designation,Salary,JoiningDate")] Employess employess)
        {
            if (id != employess.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployessExists(employess.EmployeeId))
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
            return View(employess);
        }

        // GET: Employesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employess = await _context.Employesses
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employess == null)
            {
                return NotFound();
            }

            return View(employess);
        }

        // POST: Employesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employess = await _context.Employesses.FindAsync(id);
            _context.Employesses.Remove(employess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployessExists(int id)
        {
            return _context.Employesses.Any(e => e.EmployeeId == id);
        }
    }
}
