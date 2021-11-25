using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Services
{
    public interface IEntityService<TOut, TIn, TGen>
    {
        ActionResult<List<TOut>> GetAll();

        ActionResult<TOut> GetById(int id);

        ActionResult<TOut> Create([FromBody] TIn dto);

        ActionResult Delete(int id);
    }
}