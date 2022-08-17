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
    public class UpdateConfigurationDefinitionCommandHandler : IRequestHandler<UpdateConfigurationDefinitionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateConfigurationDefinitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateConfigurationDefinitionCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ConfigDefinition.Update(request.configurationDefinition);
            _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
