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
    public class GetApplicationConfigurationDetailRequestHandler : IRequestHandler<GetApplicationConfigurationDetailRequest, ApplicationConfiguration>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApplicationConfigurationDetailRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationConfiguration> Handle(GetApplicationConfigurationDetailRequest request, CancellationToken cancellationToken)
        {
            var applicationConfiguration = _unitOfWork.AppConfig.GetById(request.Id);
            return applicationConfiguration;
        }
    }
}
