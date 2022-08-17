using DataAccess.Features.ConfigurationDefinitions.Request.Queries;
using DataAccess.Repository.IRepository;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ConfigurationDefinitions.Handlers.Queries
{
    public class GetConfigurationDefinitionDetailRequestHandler : IRequestHandler<GetConfigurationDefinitionDetailRequest, ConfigurationDefinition>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConfigurationDefinitionDetailRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ConfigurationDefinition> Handle(GetConfigurationDefinitionDetailRequest request, CancellationToken cancellationToken)
        {
            var configurationDefinition = _unitOfWork.ConfigDefinition.GetById(request.Id);
            return configurationDefinition;
        }
    }
}
