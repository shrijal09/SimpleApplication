#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace SimpleApplication.Controllers
{
    public class ApplicationConfigurationController : Controller
    {
        private readonly IApplicationConfigurationRepository _applicationConfigurationRepository;

        public ApplicationConfigurationController(IApplicationConfigurationRepository applicationConfigurationRepository)
        {
            _applicationConfigurationRepository = applicationConfigurationRepository;
        }

        // GET: ApplicationConfiguration
        public async Task<IActionResult> Index()
        {
            return View(await _applicationConfigurationRepository.GetAllAsync());
        }

        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new ApplicationConfiguration());
            }
            else
            {
                var applicationConfiguration = await _applicationConfigurationRepository.GetByIdAsync(id);
                if (applicationConfiguration == null)
                {
                    return NotFound();
                }
                return View(applicationConfiguration);
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ID,ApplicationCode,OrganizationID,ConfigurationDefinitionID,ConfigurationValue,DisabledDateTime")] ApplicationConfiguration applicationConfiguration)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _applicationConfigurationRepository.CreateApplicationConfigurationAsync(applicationConfiguration);
                }
                else
                {
                    await _applicationConfigurationRepository.UpdateApplicationConfigurationAsync(applicationConfiguration);
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationConfiguration);
        }

        public IActionResult Delete(int id)
        {
            _applicationConfigurationRepository.DeleteApplicationConfigurationAsync(id);
            return RedirectToAction(nameof(Index));
        }

    
    }
}
