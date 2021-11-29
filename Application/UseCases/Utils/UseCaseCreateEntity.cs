using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.Utils
{
    public class UseCaseCreateEntity<TOut, TIn, TDom> : IWriting<TOut, TIn>
    {
        private readonly IEntityRepository<TDom> _repository;

        public UseCaseCreateEntity(IEntityRepository<TDom> repository)
        {
            _repository = repository;
        }


        public TOut Execute(TIn dto)
        {
            var entityFromDto = Mapper.GetInstance().Map<TDom>(dto);

            var entityFromDb = _repository.Create(entityFromDto);

            return Mapper.GetInstance().Map<TOut>(entityFromDb);
        }
    }
}