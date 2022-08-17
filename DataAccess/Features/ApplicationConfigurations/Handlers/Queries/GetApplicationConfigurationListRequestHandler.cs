using DataAccess.Features.ApplicationConfigurations.Request;
using DataAccess.Repository.IRepository;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ApplicationConfigurations.Handlers.Queries
{
    public class GetApplicationConfigurationListRequestHandler : IRequestHandler<GetApplicationConfigurationListRequest, IEnumerable<ApplicationConfiguration>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApplicationConfigurationListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ApplicationConfiguration>> Handle(GetApplicationConfigurationListRequest request, CancellationToken cancellationToken)
        {
            var objApplicationConfigurationList = _unitOfWork.AppConfig.GetAll();
            return objApplicationConfigurationList;
        }
    }
}
