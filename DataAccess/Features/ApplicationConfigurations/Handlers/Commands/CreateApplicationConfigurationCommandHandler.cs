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
    public class CreateApplicationConfigurationCommandHandler : IRequestHandler<CreateApplicationConfigurationCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateApplicationConfigurationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateApplicationConfigurationCommand request, CancellationToken cancellationToken)
        {
            var applicationConfiguration = request.ApplicationConfiguration;
            _unitOfWork.AppConfig.Add(applicationConfiguration);
            _unitOfWork.Save();

            return applicationConfiguration.ID;
        }
    }
}
