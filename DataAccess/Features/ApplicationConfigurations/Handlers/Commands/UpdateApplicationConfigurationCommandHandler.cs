using DataAccess.Features.ApplicationConfigurations.Request.Commands;
using DataAccess.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.ApplicationConfigurations.Handlers.Commands
{
    public class UpdateApplicationConfigurationCommandHandler : IRequestHandler<UpdateApplicationConfigurationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateApplicationConfigurationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateApplicationConfigurationCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.AppConfig.Update(request.applicationConfiguration);
            _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
