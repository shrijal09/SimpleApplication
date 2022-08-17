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
    public class GetConfigurationDefinitionListRequestHandler : IRequestHandler<GetConfigurationDefinitionListRequest, IEnumerable<ConfigurationDefinition>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConfigurationDefinitionListRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ConfigurationDefinition>> Handle(GetConfigurationDefinitionListRequest request, CancellationToken cancellationToken)
        {
            var objConfigurationDefinitionList = _unitOfWork.ConfigDefinition.GetAll();
            return objConfigurationDefinitionList;
        }
    }
}
