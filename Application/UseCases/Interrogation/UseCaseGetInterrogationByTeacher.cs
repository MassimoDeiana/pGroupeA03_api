using System.Collections.Generic;
using System.Linq;
using Application.UseCases.Interrogation.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.Interrogation;

namespace Application.UseCases.Interrogation
{
    public class UseCaseGetInterrogationByTeacher : IQueryFiltering<List<OutputDtoInterrogation>, InputDtoGenerateInterrogationByTeacher>
    {
        private readonly IInterrogationRepository _resultRepository;

        public UseCaseGetInterrogationByTeacher(IInterrogationRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }
        
        public List<OutputDtoInterrogation> Execute(InputDtoGenerateInterrogationByTeacher dto)
        {
            var output = _resultRepository.GetByTeacher(dto.IdTeacher);
            
            return output.Select(t => Mapper.GetInstance().Map<OutputDtoInterrogation>(t)).ToList();
        }
    }
}