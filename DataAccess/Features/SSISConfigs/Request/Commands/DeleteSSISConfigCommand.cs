using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.SSISConfigs.Request.Commands
{
    public class DeleteSSISConfigCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
