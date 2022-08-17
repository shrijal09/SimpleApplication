using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ApplicationConfigurations.Request.Commands
{
    public class DeleteApplicationConfigurationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
