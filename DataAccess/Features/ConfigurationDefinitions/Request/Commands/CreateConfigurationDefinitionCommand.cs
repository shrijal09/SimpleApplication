using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ConfigurationDefinitions.Request.Commands
{
    public class CreateConfigurationDefinitionCommand : IRequest<int>
    {
        public ConfigurationDefinition configurationDefinition { get; set; }
    }
}
