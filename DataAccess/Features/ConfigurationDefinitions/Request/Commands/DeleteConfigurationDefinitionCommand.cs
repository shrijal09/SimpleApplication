using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ConfigurationDefinitions.Request.Commands
{
    public class DeleteConfigurationDefinitionCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
