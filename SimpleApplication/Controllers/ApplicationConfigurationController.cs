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
    public class ApplicationConfigurationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationConfigurationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationConfiguration> objApplicationConfigurationList = _unitOfWork.AppConfig.GetAll();
            return View(objApplicationConfigurationList);
        }

        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new ApplicationConfiguration());
            }
            else
            {
                var applicationConfiguration = _unitOfWork.AppConfig.GetById(id);
                if (applicationConfiguration == null)
                {
                    return NotFound();
                }
                return View(applicationConfiguration);
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("ID,ApplicationCode,OrganizationID,ConfigurationDefinitionID,ConfigurationValue,DisabledDateTime")] ApplicationConfiguration applicationConfiguration)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _unitOfWork.AppConfig.Add(applicationConfiguration);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.AppConfig.Update(applicationConfiguration);
                    _unitOfWork.Save();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationConfiguration);
        }

        public IActionResult Delete(int id)
        {
            _unitOfWork.AppConfig.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

    
    }
}
