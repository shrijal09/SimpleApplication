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
    public class DeleteConfigurationDefinitionCommandHandler : IRequestHandler<DeleteConfigurationDefinitionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConfigurationDefinitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteConfigurationDefinitionCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ConfigDefinition.Delete(request.Id);
            _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
