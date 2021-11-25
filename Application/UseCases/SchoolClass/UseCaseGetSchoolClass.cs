using System.Collections.Generic;
using Application.UseCases.SchoolClass.Dtos;
using Application.UseCases.Utils;
using Infrastructure.SqlServer.Repositories.SchoolClass;
using Infrastructure.SqlServer.Utils;

namespace Application.UseCases.SchoolClass
{
    public class UseCaseGetSchoolClass : IQuery<List<OutputDtoSchoolClass>>
    {
        // private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IEntityRepository<Domain.SchoolClass> _schoolClassRepository;

        public UseCaseGetSchoolClass(IEntityRepository<Domain.SchoolClass> schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public List<OutputDtoSchoolClass> Execute()
        {
            var schoolClasses = _schoolClassRepository.GetAll();

            var output = new List<OutputDtoSchoolClass>();

            foreach (var schoolClass in schoolClasses)
            {
                output.Add(Mapper.GetInstance().Map<OutputDtoSchoolClass>(schoolClass));
            }

            return output;
        }
    }
}