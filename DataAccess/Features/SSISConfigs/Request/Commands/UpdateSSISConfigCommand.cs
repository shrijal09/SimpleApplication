﻿using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Features.SSISConfigs.Request.Commands
{
    public class UpdateSSISConfigCommand : IRequest<Unit>
    {
        public SSIS_Config ssisConfig { get; set; }
    }
}