using DataAccess.Features.ConfigurationDefinitions.Request.Commands;
using DataAccess.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ConfigurationDefinitions.Handlers.Commands
{
    public class CreateConfigurationDefinitionCommandHandler : IRequestHandler<CreateConfigurationDefinitionCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateConfigurationDefinitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateConfigurationDefinitionCommand request, CancellationToken cancellationToken)
        {
            var configurationDefinition = request.configurationDefinition;
            _unitOfWork.ConfigDefinition.Add(configurationDefinition);
            _unitOfWork.Save();
            return configurationDefinition.ID;
        }
    }
}
