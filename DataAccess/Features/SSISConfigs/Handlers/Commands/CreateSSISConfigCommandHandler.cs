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
    public class CreateSSISConfigCommandHandler : IRequestHandler<CreateSSISConfigCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSSISConfigCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateSSISConfigCommand request, CancellationToken cancellationToken)
        {
            var ssisConfig = request.ssisConfig;
            _unitOfWork.SSISConfiguration.Add(ssisConfig);
            _unitOfWork.Save();
            return ssisConfig.Id;
        }
    }
}
