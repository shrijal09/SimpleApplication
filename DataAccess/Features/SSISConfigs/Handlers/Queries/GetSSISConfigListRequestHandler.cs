using DataAccess.Features.SSISConfigs.Request.Queries;
using DataAccess.Repository.IRepository;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.SSISConfigs.Handlers.Queries
{
    public class GetSSISConfigListRequestHandler : IRequestHandler<GetSSISConfigListRequest, IEnumerable<SSIS_Config>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSSISConfigListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<SSIS_Config>> Handle(GetSSISConfigListRequest request, CancellationToken cancellationToken)
        {
            var ssisConfig = _unitOfWork.SSISConfiguration.GetAll();
            return ssisConfig;
        }
    }
}
