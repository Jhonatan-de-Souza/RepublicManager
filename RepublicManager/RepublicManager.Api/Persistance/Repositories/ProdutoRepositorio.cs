﻿using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }
    }
}
