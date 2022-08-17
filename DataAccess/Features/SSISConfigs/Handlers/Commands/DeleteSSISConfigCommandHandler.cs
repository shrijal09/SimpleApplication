using DataAccess.Features.SSISConfigs.Request.Commands;
using DataAccess.Repository.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.SSISConfigs.Handlers.Commands
{
    public class DeleteSSISConfigCommandHandler : IRequestHandler<DeleteSSISConfigCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSSISConfigCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteSSISConfigCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.SSISConfiguration.Delete(request.Id);
            _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
