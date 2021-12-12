using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Result.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Result;

namespace Application.UseCases.Result
{
    public class UseCaseGenerateResult : IQueryFiltering<List<OutputDtoResult>, InputDtoGenerateResult>
    {
        private readonly IResultRepository _resultRepository;

        public UseCaseGenerateResult(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        
        public List<OutputDtoResult> Execute(InputDtoGenerateResult dto)
        {
            var output = _resultRepository.GetById(dto.IdStudent);
            
            return output.Select(t => Mapper.GetInstance().Map<OutputDtoResult>(t)).ToList();
        }
    }
}