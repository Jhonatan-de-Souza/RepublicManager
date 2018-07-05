using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Controllers.Base
{
    public interface IControllerBase<TEntity> where TEntity : class
    {
        Task<IActionResult> GetAll(TEntity entity);
        Task<IActionResult> Get(int id);
        Task<IActionResult> Create([FromBody]TEntity entity); //Resource
        Task<IActionResult> Edit(int id, [FromBody]TEntity entity); //Resource
        Task<IActionResult> Delete(int id);



    }
}
