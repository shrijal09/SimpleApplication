using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ApplicationConfigurations.Request
{
    public class GetApplicationConfigurationListRequest : IRequest<IEnumerable<ApplicationConfiguration>>
    {

    }
}
