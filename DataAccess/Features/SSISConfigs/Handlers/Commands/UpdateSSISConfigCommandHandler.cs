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
    public class UpdateSSISConfigCommandHandler : IRequestHandler<UpdateSSISConfigCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSSISConfigCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateSSISConfigCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.SSISConfiguration.Update(request.ssisConfig);
            _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
