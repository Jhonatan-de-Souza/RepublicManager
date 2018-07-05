using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Controllers.Base
{
    public class ControllerBase<TEntity> : IControllerBase<TEntity> where TEntity : class
    {
        public Task<IActionResult> Create([FromBody] TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Edit(int id, [FromBody] TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAll(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
