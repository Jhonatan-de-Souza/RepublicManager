using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting.Internal;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RepublicaRepositorio : RepositorioBase<Republica>, IRepublicaRepositorio
    {
        public RepublicaRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }

       
    }
}