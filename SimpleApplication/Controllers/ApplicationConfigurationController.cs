#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Features.ApplicationConfigurations.Request;
using DataAccess.Features.ApplicationConfigurations.Request.Commands;
using DataAccess.Repository.IRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace SimpleApplication.Controllers
{
    public class ApplicationConfigurationController : Controller
    {
        private readonly IMediator _mediator;

        public ApplicationConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<ApplicationConfiguration>>> Index()
        {
            var applicationConfiguration = await _mediator.Send(new GetApplicationConfigurationListRequest());
            return View(applicationConfiguration);
        }

        [HttpGet]
        public async Task<ActionResult<List<ApplicationConfiguration>>> AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new ApplicationConfiguration());
            }
            else
            {
                var applicationConfiguration = await _mediator.Send(new GetApplicationConfigurationDetailRequest { Id = id });
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
                    var command = new CreateApplicationConfigurationCommand { ApplicationConfiguration = applicationConfiguration };
                    _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateApplicationConfigurationCommand { applicationConfiguration = applicationConfiguration };
                    _mediator.Send(command);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationConfiguration);
        }

        public IActionResult Delete(int id)
        {
            var command = new DeleteApplicationConfigurationCommand { Id = id };
            _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    
    }
}
