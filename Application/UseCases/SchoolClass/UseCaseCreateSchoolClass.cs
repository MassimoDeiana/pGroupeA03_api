using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseCreateSchoolClass : IWriting<OutputDtoSchoolClass, InputDtoSchoolClass>
    {
        private readonly IEntityRepository<Domain.SchoolClass> _schoolClassRepository;

        public UseCaseCreateSchoolClass(IEntityRepository<Domain.SchoolClass> schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public OutputDtoSchoolClass Execute(InputDtoSchoolClass dto)
        {
            var schoolClassFromDto = Mapper.GetInstance().Map<Domain.SchoolClass>(dto);

            var schoolClassFromDb = _schoolClassRepository.Create(schoolClassFromDto);

            return Mapper.GetInstance().Map<OutputDtoSchoolClass>(schoolClassFromDb);
        }
    }
}