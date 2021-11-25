using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.SchoolClass;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseGenerateSchoolClass : IQueryFiltering<OutputDtoSchoolClass, InputDtoGenerateSchoolClass>
    {
        // private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IEntityRepository<Domain.SchoolClass> _schoolClassRepository;

        public UseCaseGenerateSchoolClass(IEntityRepository<Domain.SchoolClass> schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public OutputDtoSchoolClass Execute(string request, InputDtoGenerateSchoolClass dto, string col)
        {
            var output = _schoolClassRepository.GetById(request, dto.IdSchoolClass, col);

            return Mapper.GetInstance().Map<OutputDtoSchoolClass>(output);
        }
    }
}