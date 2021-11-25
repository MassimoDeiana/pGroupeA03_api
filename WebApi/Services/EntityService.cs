using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace pGroupeA03_api.Services
{
    public abstract class EntityService<TOut, TIn, TGen> : IEntityService<TOut, TIn, TGen>
    {
        public ActionResult<List<TOut>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ActionResult<TOut> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult<TOut> Create(TIn dto)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}