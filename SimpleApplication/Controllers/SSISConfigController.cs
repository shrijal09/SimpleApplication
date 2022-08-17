using DataAccess.Features.SSISConfigs.Request.Commands;
using DataAccess.Features.SSISConfigs.Request.Queries;
using DataAccess.Repository.IRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace SimpleApplication.Controllers
{
    public class SSISConfigController : Controller
    {
        private readonly IMediator _mediator;

        public SSISConfigController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<SSIS_Config>>> Index()
        {
            var ssisConfig = await _mediator.Send(new GetSSISConfigListRequest());
            return View(ssisConfig);
        }

        [HttpGet]
        public async Task<ActionResult<List<SSIS_Config>>> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new SSIS_Config());
            }
            else
            {
                var ssisConfig = await _mediator.Send(new GetSSISConfigDetailRequest { Id = id });
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
                    var command = new CreateSSISConfigCommand { ssisConfig = ssisConfig };
                    _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateSSISConfigCommand { ssisConfig = ssisConfig };
                    _mediator.Send(command);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ssisConfig);
        }

        public IActionResult Delete(int id)
        {
            var command = new DeleteSSISConfigCommand { Id = id };
            _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
