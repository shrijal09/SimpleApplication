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
    public class DeleteApplicationConfigurationCommandHandler : IRequestHandler<DeleteApplicationConfigurationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteApplicationConfigurationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteApplicationConfigurationCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.AppConfig.Delete(request.Id);
            _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
