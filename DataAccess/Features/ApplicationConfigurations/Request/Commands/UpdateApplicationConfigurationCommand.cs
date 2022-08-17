using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ApplicationConfigurations.Request.Commands
{
    public class UpdateApplicationConfigurationCommand : IRequest<Unit>
    {
        public ApplicationConfiguration applicationConfiguration { get; set; }
    }
}
