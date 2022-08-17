using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ConfigurationDefinitions.Request.Commands
{
    public class UpdateConfigurationDefinitionCommand : IRequest<Unit>
    {
        public ConfigurationDefinition configurationDefinition { get; set; }
    }
}
