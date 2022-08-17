#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Features.ConfigurationDefinitions.Request.Commands;
using DataAccess.Features.ConfigurationDefinitions.Request.Queries;
using DataAccess.Repository.IRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace SimpleApplication.Controllers
{
    public class ConfigurationDefinitionController : Controller
    {
        private readonly IMediator _mediator;

        public ConfigurationDefinitionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: ConfigurationDefinition
        [HttpGet]
        public async Task<ActionResult<List<ConfigurationDefinition>>> Index()
        {
            var configurationDefinitions = await _mediator.Send(new GetConfigurationDefinitionListRequest());
            return View(configurationDefinitions);
        }

        [HttpGet]
        public async Task<ActionResult<List<ConfigurationDefinition>>> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new ConfigurationDefinition());
            }
            else
            {
                var configurationDefinition = await _mediator.Send(new GetConfigurationDefinitionDetailRequest { Id = id });
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
                    var command = new CreateConfigurationDefinitionCommand { configurationDefinition = configurationDefinition };
                    _mediator.Send(command);
                }
                else
                {
                    var command = new UpdateConfigurationDefinitionCommand { configurationDefinition = configurationDefinition };
                    _mediator.Send(command);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(configurationDefinition);
        }

        public IActionResult Delete(int id)
        {
            var command = new DeleteConfigurationDefinitionCommand { Id = id };
            _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
