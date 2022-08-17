using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.SSISConfigs.Request.Queries
{
    public class GetSSISConfigListRequest : IRequest<IEnumerable<SSIS_Config>>
    {
    }
}
