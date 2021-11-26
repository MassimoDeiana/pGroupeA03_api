using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseGenerateSchoolClass : IQueryFiltering<OutputDtoSchoolClass, InputDtoGenerateSchoolClass>
    {
        private readonly IEntityRepository<Domain.SchoolClass> _schoolClassRepository;

        public UseCaseGenerateSchoolClass(IEntityRepository<Domain.SchoolClass> schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public OutputDtoSchoolClass Execute(InputDtoGenerateSchoolClass dto)
        {
            var output = _schoolClassRepository.GetById(dto.IdSchoolClass);

            return Mapper.GetInstance().Map<OutputDtoSchoolClass>(output);
        }
    }
}