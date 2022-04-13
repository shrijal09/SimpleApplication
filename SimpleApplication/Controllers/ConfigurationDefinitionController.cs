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
    public class ConfigurationDefinitionController : Controller
    {
        private readonly IConfigurationDefinitionRepository _configurationDefinitionRepository;

        public ConfigurationDefinitionController(IConfigurationDefinitionRepository configurationDefinitionRepository)
        {
            _configurationDefinitionRepository = configurationDefinitionRepository;
        }

        // GET: ConfigurationDefinition
        public async Task<IActionResult> Index()
        {
            return View(await _configurationDefinitionRepository.GetAllAsync());
        }

        public async Task<IActionResult> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new ConfigurationDefinition());
            }
            else
            {
                var configurationDefinition = await _configurationDefinitionRepository.GetByIdAsync(id);
                if (configurationDefinition == null)
                {
                    return NotFound();
                }
                return View(configurationDefinition);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ID,ConfigurationType,ConfigurationDescription,DefaultValue,CreateUserID,CreateDateTime,LastUpdateUserID,LastUpdateDateTime")] ConfigurationDefinition configurationDefinition)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _configurationDefinitionRepository.CreateConfigurationDefinitionAsync(configurationDefinition);
                }
                else
                {
                   
                    await _configurationDefinitionRepository.UpdateConfigurationDefinitionAsync(configurationDefinition);
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(configurationDefinition);
        }

        public IActionResult Delete(int id)
        {
            _configurationDefinitionRepository.DeleteConfigurationDefinitionAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
