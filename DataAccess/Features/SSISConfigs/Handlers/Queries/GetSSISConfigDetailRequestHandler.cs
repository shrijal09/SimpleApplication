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
    public class GetSSISConfigDetailRequestHandler : IRequestHandler<GetSSISConfigDetailRequest, SSIS_Config>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSSISConfigDetailRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SSIS_Config> Handle(GetSSISConfigDetailRequest request, CancellationToken cancellationToken)
        {
            var ssisConfig = _unitOfWork.SSISConfiguration.GetById(request.Id);
            return ssisConfig;
        }
    }
}
