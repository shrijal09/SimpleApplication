using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace SimpleApplication.Controllers
{
    public class SSISConfigController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SSISConfigController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<SSIS_Config> obj = _unitOfWork.SSISConfiguration.GetAll();
            return View(obj);
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new SSIS_Config());
            }
            else
            {
                var ssisConfig = _unitOfWork.SSISConfiguration.GetById(id);
                if (ssisConfig == null)
                {
                    return NotFound();
                }
                return View(ssisConfig);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, SSIS_Config ssisConfig)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _unitOfWork.SSISConfiguration.Add(ssisConfig);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.SSISConfiguration.Update(ssisConfig);
                    _unitOfWork.Save();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ssisConfig);
        }

        public IActionResult Delete(int id)
        {
            _unitOfWork.SSISConfiguration.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
