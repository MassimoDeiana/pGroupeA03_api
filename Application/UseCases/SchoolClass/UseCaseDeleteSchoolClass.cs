using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseDeleteSchoolClass : IDeleting<InputDtoGenerateSchoolClass>
    {
        private readonly IEntityRepository<Domain.SchoolClass> _schoolClassRepository;

        public UseCaseDeleteSchoolClass(IEntityRepository<Domain.SchoolClass> schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public bool Execute( InputDtoGenerateSchoolClass dto)
        {
            return _schoolClassRepository.Delete(dto.IdSchoolClass);
        }
    }
}