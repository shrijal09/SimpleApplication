using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.SSISConfigs.Request.Queries
{
    public class GetSSISConfigDetailRequest : IRequest<SSIS_Config>
    {
        public int Id { get; set; }  
    }
}
