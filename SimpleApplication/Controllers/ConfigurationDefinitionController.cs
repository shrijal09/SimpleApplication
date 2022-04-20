#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace SimpleApplication.Controllers
{
    public class ConfigurationDefinitionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationDefinitionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: ConfigurationDefinition
        public IActionResult Index()
        {
            IEnumerable<ConfigurationDefinition> objConfigurationDefinitionList = _unitOfWork.ConfigDefinition.GetAll();
            return View(objConfigurationDefinitionList);
        }

        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new ConfigurationDefinition());
            }
            else
            {
                var configurationDefinition = _unitOfWork.ConfigDefinition.GetById(id);
                if (configurationDefinition == null)
                {
                    return NotFound();
                }
                return View(configurationDefinition);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("ID,ConfigurationType,ConfigurationDescription,DefaultValue,CreateUserID,CreateDateTime,LastUpdateUserID,LastUpdateDateTime")] ConfigurationDefinition configurationDefinition)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _unitOfWork.ConfigDefinition.Add(configurationDefinition);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.ConfigDefinition.Update(configurationDefinition);
                    _unitOfWork.Save();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(configurationDefinition);
        }

        public IActionResult Delete(int id)
        {
            _unitOfWork.ConfigDefinition.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
