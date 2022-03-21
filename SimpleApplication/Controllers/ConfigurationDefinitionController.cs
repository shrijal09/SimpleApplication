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
    public class ConfigurationDefinitionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationDefinitionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConfigurationDefinition
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConfigurationDefinition.ToListAsync());
        }

        // GET: ConfigurationDefinition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationDefinition = await _context.ConfigurationDefinition
                .FirstOrDefaultAsync(m => m.ID == id);
            if (configurationDefinition == null)
            {
                return NotFound();
            }

            return View(configurationDefinition);
        }

        // GET: ConfigurationDefinition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConfigurationDefinition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ConfigurationType,ConfigurationDescription,DefaultValue,CreateUserID,CreateDateTime,LastUpdateUserID,LastUpdateDateTime")] ConfigurationDefinition configurationDefinition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(configurationDefinition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(configurationDefinition);
        }

        // GET: ConfigurationDefinition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationDefinition = await _context.ConfigurationDefinition.FindAsync(id);
            if (configurationDefinition == null)
            {
                return NotFound();
            }
            return View(configurationDefinition);
        }

        // POST: ConfigurationDefinition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ConfigurationType,ConfigurationDescription,DefaultValue,CreateUserID,CreateDateTime,LastUpdateUserID,LastUpdateDateTime")] ConfigurationDefinition configurationDefinition)
        {
            if (id != configurationDefinition.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configurationDefinition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigurationDefinitionExists(configurationDefinition.ID))
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
            return View(configurationDefinition);
        }

        // GET: ConfigurationDefinition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var configurationDefinition = await _context.ConfigurationDefinition
                .FirstOrDefaultAsync(m => m.ID == id);
            if (configurationDefinition == null)
            {
                return NotFound();
            }

            return View(configurationDefinition);
        }

        // POST: ConfigurationDefinition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var configurationDefinition = await _context.ConfigurationDefinition.FindAsync(id);
            _context.ConfigurationDefinition.Remove(configurationDefinition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfigurationDefinitionExists(int id)
        {
            return _context.ConfigurationDefinition.Any(e => e.ID == id);
        }
    }
}
