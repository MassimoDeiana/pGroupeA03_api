using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.SchoolClass;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseDeleteSchoolClass : IDeleting<InputDtoGenerateSchoolClass>
    {
        // private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IEntityRepository<Domain.SchoolClass> _schoolClassRepository;

        public UseCaseDeleteSchoolClass(IEntityRepository<Domain.SchoolClass> schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public bool Execute(string request, InputDtoGenerateSchoolClass dto, string col)
        {
            return _schoolClassRepository.Delete(request, dto.IdSchoolClass, col);
        }
    }
}