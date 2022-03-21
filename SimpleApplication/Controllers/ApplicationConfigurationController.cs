#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleApplication.Data;
using SimpleApplication.Models;

namespace SimpleApplication.Controllers
{
    public class ApplicationConfigurationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationConfigurationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationConfiguration
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationConfiguration.ToListAsync());
        }

        // GET: ApplicationConfiguration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationConfiguration = await _context.ApplicationConfiguration
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicationConfiguration == null)
            {
                return NotFound();
            }

            return View(applicationConfiguration);
        }

        // GET: ApplicationConfiguration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationConfiguration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ApplicationCode,OrganizationID,ConfigurationDefinitionID,ConfigurationValue,DisabledDateTime")] ApplicationConfiguration applicationConfiguration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationConfiguration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationConfiguration);
        }

        // GET: ApplicationConfiguration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationConfiguration = await _context.ApplicationConfiguration.FindAsync(id);
            if (applicationConfiguration == null)
            {
                return NotFound();
            }
            return View(applicationConfiguration);
        }

        // POST: ApplicationConfiguration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ApplicationCode,OrganizationID,ConfigurationDefinitionID,ConfigurationValue,DisabledDateTime")] ApplicationConfiguration applicationConfiguration)
        {
            if (id != applicationConfiguration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationConfiguration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationConfigurationExists(applicationConfiguration.ID))
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
            return View(applicationConfiguration);
        }

        // GET: ApplicationConfiguration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationConfiguration = await _context.ApplicationConfiguration
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicationConfiguration == null)
            {
                return NotFound();
            }

            return View(applicationConfiguration);
        }

        // POST: ApplicationConfiguration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationConfiguration = await _context.ApplicationConfiguration.FindAsync(id);
            _context.ApplicationConfiguration.Remove(applicationConfiguration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationConfigurationExists(int id)
        {
            return _context.ApplicationConfiguration.Any(e => e.ID == id);
        }
    }
}
