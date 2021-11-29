using System.Collections.Generic;
using System.Linq;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Utils
{
    public class UseCaseGetEntity<TOut, TDom> : IQuery<List<TOut>>
    {
        private readonly IEntityRepository<TDom> _repository;

        public UseCaseGetEntity(IEntityRepository<TDom> repository)
        {
            _repository = repository;
        }

        public List<TOut> Execute()
        {
            var entities = _repository.GetAll();

            return entities.Select(t => Mapper.GetInstance().Map<TOut>(t)).ToList();
        }
    }
}